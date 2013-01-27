
// **** DETERMINING WHICH CONSTRYUCTOR TO USE ****
// The main DI pattern is Constructor Injection
// A known constructor parameter is one which has been explicitly bound
// An unknown constructor parameter is one which has not been explicitly bound even if it has a resolvable constructor the following order defines which constructor is used
// 1. User defined costructor marked with [Inject] attribute
// 2. The constructor with the most known bound parameters.
// 3. The default parameterless constructor

// **** PROPERTY / METHOD INJECTION
// Properties and methods marked with the [Inject] property will be resolved imediatly after the selected constructor
// Properties are required to be public set and private get
// Methods should be public and return void

[Inject]
public void AMethod(IClass aClass)
{
    this.aClass = aClass;
}

[Inject]
public IClass Property { private get; set; }

// **** BIND TO ****
// Classes are automatically bound to themselves
Bind<IClass>().ToSelf( )			// Explicit self binding
Bind<IClass>().To<Class>();  			// Bind to class
Bind<IClass>().ToConstant( )			// Binding with constant (the returned class), implicitly sets scope to InSingletonScope
Bind<IClass>().ToConstructor( )			// Bind with constructor 
Bind<IClass>().ToMethod( )			// Binding with method
Bind<IClass>().ToProvider( )			// Binding with provider, class with parent of Provider<T> allowing addressing of complex initiation


// **** BINDING SCOPE ****
// The lifetime of an instance can be defined via the scope of the binding
// The default scope is InTransientScope
kernel.Bind<IClassA>().To<B>(ClassA).InTransientScope()  	// Always create an instance per Get call 
kernel.Bind<IClassA>().To<B>(ClassA).InSingletonScope()		// Create only one instance
kernel.Bind<IClassA>().To<B>(ClassA).InThreadScope()		// Create one instance per thread and always return this
kernel.Bind<IClassA>().To<B>(ClassA).InRequestScope()		// Create one instance per web request and return this
kernel.Bind<IClassA>().To<B>(ClassA).InScope(Func<object>)	// Returns an object associated with the lifetime. The same instances is returned for the same life time of this associated lifetime object. Once this has been garbage collected our bound object will be recreated

// **** CONDITIONAL BINDING ****
Bind<IClass>().To<Class>().Named("AName");  				// Named Binding
Bind<IClass>().To<Class>().WithConstructorArgument("Iclass", delegat/object); // Constructor Argument
Bind<IClass>().To<Class>().WithMetadata("AMetaName", false); 		// Derrived Attribute Bindings
Bind<IClass>().To<Class>().WithParameter(new ConstructorArgument/Property("IClass/PropertyName", new XYZ() ); // WithConstructorArgument is a short cut to this
Bind<IClass>().To<Class>().WithPropertyValue(ProprtyName, delegate/object); // Explicit property injection								
Bind<IClass>().To<Class>().When();					// Explicit Conditional binding
Bind<IClass>().To<Class>().WhenAnyAnchestorNamed("AnyParentInAncestry"); // When any class in ancestry is named 
Bind<IClass>().To<Class>().WhenClassHas<AnAttribute>();  		// Binding with attributes based helpers
Bind<IClass>().To<Class>().WhenInjectedInto(typeof(AClass)); 		// Conditional injected into AClass or any derrived classes
Bind<IClass>().To<Class>().WhenInjectedExactlyInto(typeof(AClass));	// Conditional injected into AClass and not any derrived classes		
Bind<IClass>().To<Class>().WhenMemberHas<AnAttribute>();  		// Binding with attributes based helpers
Bind<IClass>().To<Class>().WhenParentNamed("ParentName");		// Bind when the direct parent is named
Bind<IClass>().To<Class>().WhenTargerHas<AnAttribute>(); 		// Binding with attributes based helpers


// **** MULTIPLE BINDING WITH BindingConfiguration ****
// Default bind up to 4 however more can be found via caching and provinding the bind config.
var bindingConfiguration =
    Bind<IInterface1, IInterface2, IInterface3, IInterface4>()
        .To<Implementation>()
        .BindingConfiguration;
kernel.AddBinding(new Binding(typeof(IInterface5), bindingConfiguration));
kernel.AddBinding(new Binding(typeof(IInterface6), bindingConfiguration));


// **** OnActivation AND OnDeactivation EVENTS
// Trigger evets on the activation and deactivation
Bind<IClass>().To<Class( ).OnActivation( x => x.ActivationMethod())		// Called when an object is activate (instantiated)
Bind<IClass>().To<Class( ).OnDeactivation(x => x.DeactivationMethod())		// Called when an object is deactivate (disposed?)

// **** KERNEL CREATION **** 
IKernel kernel = new StandardKernel();

// *** KERNEL MODULES *** 
// Provide a grouping of registring bindings
public class WarriorModule : NinjectModule
{
    public override void Load() { } 	// Binding code goes in here
    public override void OnLoad() { } 	// OnLoad event
    public override void OnUnLoad() { } // OnUnload event
}

IKernel kernel = new StandardKernel(new AKernelModule());
IKernel kernel = new StandardKernel(new Module1(), new Module2(), ...);
kernel.Load/UnLoad("*.dll"); // Load / Unload all Kernel Modules within dll
kernel.Load.UnLoad(AppDomain.CurrentDomain.GetAssemblies()); // // Load / Unload all Kernel Modules within the current domains dll's


// **** GET / RESOLVE / INJECT ****
// During execution of code request instance of injected class via the kerel
// Any classes passed in as parameters to the constructor or INJECT marked methods/properties will be automatically resolved.
var aClass = kernel.Get<IClass>();
var classes = kernel.Get<IWarrior>( new ConstructorArgument( "IClass", new AClass() ) );
var classes = kernel.GetAll<IClass>();

// **** MULTIPLE BINDINGS
public ClassName( IEnumerable<IClass> classes) // An instance off all classes implementing the interface will be injected in

// **** NAMED BINDING ****
Bind<IClass>().To<ClassA>().Named("First"); 	// Name the binding during binding
Bind<IClass>().To<ClassB>().Named("Second");
kernel.Get<IClass>("First"); 			// Resolve the bind by providing the name
public ClassC ( [Named("First") IClass aClass]  // Consuctors, Methods and Properties can have named parameters to resolve their injection


// **** DERRIVED ATTRIBUTE BINDINGS ****
// Define an attribute
[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = true, Inherited = true)]
public class IsSomething : ConstraintAttribute {
    public bool Matches(IBindingMetadata metadata) {
        return metadata.Has("IsSomething") && metadata.Get<bool>("IsSomething");
    }
}

Bind<IClass>().To<AClass>().WithMetadata("IsSomething", false);
Bind<IClass>().To<BClass>().WithMetadata("IsSomething", true);

public AnotherClass([IsSomething] IClass aClass) {} // face resolves to BClass

// TODO: try this bit
kernel.Get<IClass>(metadata => metadata.Has("IsSomething") && metadata.Get<bool>("IsSomething") == false ) // resolves to AClass

// **** BINDING WITH ATTRIBUTE BASED HELPERS ****
// The Target: the parameter being injected into
// The Member: the property, method or constructor itself
// The Class: the class Type within which the Member or Target is defined within

[AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = true)]
public class WhenClassHas : Attribute{ }

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = true, Inherited = true)]
public class WhenMemberHas : Attribute{}

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = true, Inherited = true)]
public class WhenTargetHas : Attribute{}

public class InjectWhenMemberAndTargetHas
{
	[Inject, WhenMemberHas]
	public IClass WhenMemberHas { get; set; } // Member has an attribute
	public IClass WhenTargetHas { get; set; }
	public InjectWhenMemberAndTargetHas([WhenTargetHas] IClass aClass){WhenTargetHas = aClass;} // target has an attribute
}

[WhenClassHas]	
public class InjectWhenClassHas
{
	[Inject] // Class is marked with attriibute. binding is done by class
	public IClass WhenClassHas { get; set; }
}

Bind<IClass>().To<KnownC>().WhenClassHas<WhenClassHas>();
Bind<IClass>().To<KnownD>().WhenTargetHas<WhenTargetHas>();
Bind<IClass>().To<KnownE>().WhenMemberHas<WhenMemberHas>();

// **** BIND WITH METHOD ****
// Used to bind to factory methods.
// Here we are passing in the reques5 context tyoe
Bind<IClass>().ToMethod( context => AFactory.Create( context.Request.Target.Type ) )
Bind<IClass>().ToMethod( x => new ClassC(x.Kernel.Get<IClassA>(), x.Kernel.Get<IClassB>()));

// **** BIND TO PROVIDER ****
// Binding with provider, class with parent of Provider<T> allowing addressing of complex initiation
Bind<IClass>().ToProvider(new AProvider())

public class AProvider : Provider<AClass>
{
    protected override AClass CreateInstance(IContext context)
    {
        return new AClass(); // Do some complex initialization here.        
    }
}

// **** BIND TO CONSTRUCTOR ****
Bind<IMyService>().ToConstructor( ctorArg => new ClassC(ctorArg.Inject<IClassA>(), ctorArg.Inject<IClassB>())); // TODO what is the difference between constructor and method binding

// **** BIND WITH CONSTRUCTOR ARGUMENT ****
Bind<IClass>().To<Class>().WithConstructorArgument("ParameterName", x =>x.Kernel.Get<IClass>()); // 

// **** BIND WITH EXPLICIT CONDITIONAL BINDING ****
Bind<IClass>().To<ClassA>().When(request => request.Target.Member.Name.StartsWith("ClassName"));
Bind<IClass>().To<ClassB>().When(request => request.Target.Type.Namespace.StartsWith("NameSpace.ClassName"));
