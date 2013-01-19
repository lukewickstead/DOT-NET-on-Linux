// **** AGGREGATE ****

// Aggregate Linq Ext methods can be applied to natural Linq
.Count()
.Min()
.Max()
.Average()
.Sum()


// Aggregate
var count = (from p in people 
 		select p).Count ();		

// Conditional Aggregate
var count = (from p in people
             where p.Gender == Gender.Male
             select p).Count ();

// Nested Aggregate
var samplePeople = from p in people
		   select new { Name= p.Name, 
				ChildrenCount = 
				  (from c in p.Children
				   where c.Gender == Gender.Female
				   select c).Count () };

// Grouped Aggregate
var children = from p in people 
	group p by p.Gender into peopleGenders
		let minKids = peopleGenders.Min( x => x.Children.Count())
	select new { Gender = peopleGenders.Key, Value = peopleGenders.Count() };

// Let satement
var children = from p in people 
	let x = peopleGenders.Count( x => x.Children.Count())
	select x	

// **** CONVERSIONS ****
// All conversions functions should be done with Linq ext methods ToArray(), ToList(), ToDictionary(), OfType(), Cast(); see Linq Ext cheet sheet here.

// **** ELEMENT ****
// All element functions should be done with Linq ext methods First(), FirstOrDefault(), Last(), LastOrDefault(), ElementAt(); see Linq Ext cheet sheet here.

// **** FILTER ****
// Where filter
var count = (from p in people
             where p.Age < 30
             select p).Count ();

// Drilled where filter
var count = (from p in people 
             where p.Children.Count () > 0 
             select p).Count ();

// **** GENERATION ****
// All generation functions should be done with Linq ext methods Enumerable.Range() and Enumerable.Repeat(); see Linq Ext cheet sheet here

// **** GROUPING ****
// Group by gender and count...
var samplePeople = from p in people 
	group p by p.Gender into gens
	select new { Key = gens.Key, Value = gens.Count()};

// Split into groups of gender by grouping on Name
var samplePeople = from p in people 
	group p by p.Gender into gens
	select new { Key = gens.Key, Value = gens.OrderBy( x => x.Name)};

		
// **** ORDERING ****
// Order ASC
var orderdPeople = from p in people
	orderby p.Name
	select new { p.Name, p.Age, p.Children, p.Gender };

// Order DES
var orderdPeople = from p in people
	orderby p.Name descending 
	select new { p.Name, p.Age, p.Gender, p.Children };

// Order by multiple fields
var orderdPeople = from p in people 
	orderby p.Age, p.Name descending
	select new { p.Name, p.Age, p.Gender, p.Children };

// Reverses the order
var orderdPeople = (from p in people
	orderby p.Name
    select new { p.Name, p.Age, p.Gender, p.Children }).Reverse ();


// **** PARTITIONING ****
// All partitioning functions should be done with Linq ext methods Take(), Skip(), TakeWhile() SkipWhile(); see Linq Ext cheet sheet here

// **** PROJECTION ****
// Select column
var allFemaleNames = from p in people 
           			where p.Gender == Gender.Female
           			orderby p.Name descending
					select p.Name;
// Select columns into anonymous type
var parentsNameAndAge = from p in people
	where p.Gender == Gender.Female 
	select new { Name =  p.Name, Age = p.Age };

// Select element
var boysWithFemaleParents = from parent in people
	where parent.Gender == Gender.Female 
	from children in parent.Children 
	where children.Gender == Gender.Male All
	select children;

// **** QUANTIFIERS ****
// Any() and All() functions can be applied here

// Any exists
var isAnyPeople = (from p in people 
                   where p.Gender == Gender.Unknown 
                   select p).Any (); 

// Any exists in group
var isAnyPeople = from p in people
    			  where p.Children.Any (child => child.Gender == Gender.Unknown)							         
				  group p by p.Gender into genders
                  select new { Gender = genders.Key, People = genders};


// **** SETS ****
// Most set functions should be done with Linq ext methods Take(), Skip(), TakeWhile() SkipWhile(); see Linq Ext cheet sheet here
// inner join between person and gender description
var foo = from aPerson in people
	join aDes in genderDescriptions on aPerson.Gender equals aDes.Gender  
select new { Name = aPerson.Name, Gender = aPerson.Gender, Desc = aDes.Descripion};
