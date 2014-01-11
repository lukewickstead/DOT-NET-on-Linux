// ******** JQUERY SELECTORS ********

// Selectors
$('#id');			// html id
$('a');				// html tag
$('.cssclass');			// css class
$('#navigationBar a'); 	    	// descendants
$('#body > a'); 		// child nodes
$('#h2 + div');			// adjacent siblings

// Compounds selections
= is exactly equal
!= is not equal
^= is starts with
$= is ends with
*= is contains
id 
name
href

// Attribute Selectors
$('img[alt]');			// has attribute set
$('input[type=text]');		// has attribute value equal to
$('a[href^=http://]');		// has attribute value starting with
$('a[href$=.pdf]');		// has attribute value ending with
$('a[href*=google.com]'); 	// has attribute value containing

// Filters
$('tr:even');			// even elements
$('.strippedTbl tr:even');	// even elements
$('.strippedTbl tr:odd');	// odd elements
$('a:not(.myClass)');		// elements with exclusion filter
$('a:not([href^=http://])');	// elements with exclusion filter
$('li:has(a)');			// elements with inclusion filter
$('a:contains(Click Me!)');	// elements with inclusion text
$('div:hidden').show();		// elements with hidden filter

// ******** METHODS ********
$('.foo').show().width(300);	// Inline chaining
$('.foo').show()				// Multi line chaining
	.width(300)				
	.height(300);
			
$('.foo').html();			// replaces Javascript innerHtml 
$('.foo').html = '<br>';		// replaces Javascript innerHtml 
$('.foo').text = '<br>';		// encodes html (to show code in html)


// Adding and replacing page content
$('.foo').append('<br>')	// adds as last child element of selected element
$('.foo').prepend('<br>')	// adds as first child element of selected element
$('.foo').before('<br>')	// adds element before
$('.foo').after('<br>')		// adds element aftter
$('.foo').remove()		// removes element
$('.foo').replace('<br>')	// replaces element
$('#AnID tbody:last').append("<tr><td></td></tr>"); // Add html into a section



// Setting and Reading Tag Attributes
$('.foo').addClass('class')		// adds CSS Class
$('.foo').removeClass('class')	    	// remove CSS Class
$('.foo').toggleClass('class')	    	// toggle add/remove CSS Class
$('.foo').css('background-colour')	// Get CSS property.
$('.foo').css('font-size', '200%')	// Set CSS property.
$('.foo').css({
			'background-colour' : '#FF0000',
			'font-size' : '200%'
			});								// Set multiple CSS properties.

// Reading, setting and removing HTML Attributes
$('img').attr('src')			// Get attribute
$('img').attr('src', 'foo.jpg');	// Set attribute
$('img').removeAttr('src');		// Remove attribute
$('img').fadeOut();			// Set attribute

// Examples
$("input[type=text]").val('');							// All text items
$("input[id^=ProductWrapperName][value='Foo']").get(0).id 			// Starts with and has value
$("input[id^=ProductWrapperProductType][value='" + productType + "']").get(0) 	// Starts with and has value
$("input[id^=TrustP][id$=Trustee][value='Yes']").size(); 			// Starts with and ends with and value
$("text[id^=ProductWrapperName]:contains('Foo')")  				// Text box id starts with html contains
$('#chktable' + asTable + 'Match' + jnRecordRow + ':checked').val() != null 	// Element is checked
$('#contributionsInputPanel input').val('');					// Id and input
$("#myid").length > 0								// Element by Id exists
$("#input").val("Hello");							// Set value
$("#input").val();								// Get value	
$('#' + prefix + 'CrystallisedRegularIncomeRadioNo').attr("checked", true );    // Check item        
$("input[name=DiscardOption]:checked").val();					// Item is checked
$(".selector").attr("checked", false); 						// Check item
$("input[name='Thirdpartytype1']:checked").val();				// Item is checked
$("input").attr("readOnly", true); 						// Set readonly
$("input").removeAttr("readOnly");						// Remove readonly
$("input").attr("disabled", true); 						// Disable
$("input").attr("disabled", ''); 						// Remove readonly	
$("select").removeAttr("disabled");
$("input").show();
$("input").hide();




// ******** LOOPS *********

$('img').each(functionName);		// Named function
$('img').each(function(){		// Anon function
	this				// old school element
	$(this)				// jquery element
	});

var myData = { firstName: 'Bob', lastName:, 'Smith'};	
$('#foo').bind('click', myData, functionName);
var fname = evt.data.firstName;
$('#foo').bind('click', functionName);


// ******** EVENTS ********
// Registered as functions (see each above)
// Mouse Events
$('.foo').click(functionName);			// called upon release 
$('.foo').dblclick(functionName);		// called upon second release
$('.foo').mousedown(functionName);		// called upon left click down
$('.foo').mouseup(functionName);		// called upon release
$('.foo').mouseover(functionName);		// called when mouse enters area
$('.foo').mouseout(functionName);		// called when mouse leaves area
$('.foo').mousemove(functionName);		// called when mouse moves

// Document / window Events
$(document).load(functionName);			// called after everything loaded; ready better 
$(window).resize(functionName);			// called upon release of resize (not always) 		
$(window).scroll(functionName);			// called upon release of scroll (not always)
$(window).unload(functionName);			// called upon exit (not always)

// Form Events
$('.foo').submit(functionName);			// called upon submit of form 
$('.foo').reset(functionName);			// called upon reset of form 
$('.foo').change(functionName);			// called entity change
$('.foo').focus(functionName);			// called entity focus recieved
$('.foo').blur(functionName);			// called entity focus released

// Keyboard Event
$('.foo').keypress(functionName);		// called upon key release
$('.foo').keydown(functionName);		// called upon key down
$('.foo').keyup(functionName);			// called upon key release

// JQuery Events

// You can chain events
$(document).ready(functionName)			// Called when javascript manimulation should be made							
$('#id').hover(showFunc, hideFunc)		// Encompas mouseover and moustout events
$('#id').toggle(togOffFunc, togOffFunc)		// Encompas toggle on and off functions

// Event object
$(document).click(function(evt){});		// Passed into events
evt.pageX;				        // distance from mouse pointer to left page edge
evt.pageY;				        // distant from mouse poiner to top page edge
evt.screenX;			                // distance from mouse pointer to monitor edge x
evt.screenY;			                // distance fom mouse pointer to monitor edge y
evt.shiftKey;			                // boolean indicating if shift key press *
evt.which;				        // numeric code of key press
evt.target;				        // element bound upon
evt.data;					// data passed in with bind method

String.fromCharCode(evt.which);			// * Get char from key code

// Stoppnig and removing events
evt.preventDefault();				    // prevents other events getting raised
return false;					    // shorthand of preventDefault
evt.stopPropagation();				    // Prevents parent elements recieving bubble events
$(document).unbind('click')			    // remove registered events 							

















 










			
			
			
			









			
















