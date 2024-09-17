jQuery(document).ready(function(){

	"use strict";
	
	jQuery(window).on('scroll',function(e){
		e.preventDefault();
		arlo_tm_totop_myhide();
	});
	
	jQuery(window).on('resize',function(){
		arlo_tm_responsive();
	});

	jQuery(window).on("load", function () {

		setTimeout(function () {
			arlo_tm_responsive();
			arlo_tm_jarallax();
			arlo_tm_list_height();
			arlo_tm_totop();
			arlo_tm_totop_myhide();

			arlo_tm_switcher();
			arlo_tm_hamburger();

			arlo_tm_data_images();

		}, 1000);
	});


	/* Creative Works List Page Select Box */

	$("body").on('change', '.select-creative-work', function () {
		const SelectedCreativeWorkType = $(this).val();

		if (SelectedCreativeWorkType == "0") {
			$('[data-creative-type]').removeClass("d-none");
		}
		else {
			$('[data-creative-type]').addClass("d-none");
			$('[data-creative-type="' + SelectedCreativeWorkType + '"]').removeClass("d-none");
		}

	});

	/* Creative Works List Page Select Box */


});


function arlo_tm_responsive(){
	
	"use strict";
	
	var leftpart			= jQuery('.arlo_tm_leftpart_wrap');
	var rightpart			= jQuery('.arlo_tm_rightpart');
	var WW					= jQuery(window).width();
	
	if(WW<1040){
		leftpart.addClass('hide');
		rightpart.addClass('full');
	}else{
		leftpart.removeClass('hide');
		rightpart.removeClass('full');
	}
}

function arlo_tm_jarallax(){
	
	"use strict";
	
	jQuery('.jarallax').each(function(){
		var element			= jQuery(this);
		var	customSpeed		= element.data('speed');
		
		if(customSpeed !== "undefined" && customSpeed !== ""){
			customSpeed = customSpeed;
		}else{
			customSpeed 	= 0.5;
		}
		
		element.jarallax({
			speed: customSpeed,
			automaticResize: true
		});
	});
}

function arlo_tm_list_height(){
	
	"use strict";
	
	var div			= jQuery('.about_short_contact_wrap');
	var list		= div.find('li:nth-of-type(2n)');
	
	list.after("<div class='clearfix'></div>");
}

new WOW().init();

function arlo_tm_totop(){
	
	"use strict";
	
	jQuery(".arlo_tm_totop").on('click', function(e) {
		e.preventDefault();		
		jQuery("html, body").animate({ scrollTop: 0 }, 'slow');
		return false;
	});
}

function arlo_tm_totop_myhide(){
	
	"use strict";
	
	var toTop		=jQuery(".arlo_tm_totop");
	if(toTop.length){
		var topOffSet 	=toTop.offset().top;
		
		if(topOffSet > 1000){
			toTop.addClass('opened');	
		}else{
			toTop.removeClass('opened');
		}
	}
}

function arlo_tm_switcher(){
	
	"use strict";
	
	var switcherOpener				= jQuery('.arlo_tm_resize');
	var switcherIcon				= jQuery('.arlo_tm_leftpart_wrap .arlo_tm_resize i');
	var leftPart					= jQuery('.arlo_tm_leftpart_wrap');
	var rightPart					= jQuery('.arlo_tm_rightpart');
	
	switcherOpener.on('click',function(){
		if(switcherOpener.hasClass('opened')){
			switcherOpener.removeClass('opened');
			switcherIcon.removeClass('opened');
			leftPart.removeClass('opened');
			rightPart.removeClass('opened');
		}
		else {
			switcherOpener.addClass('opened');
			switcherIcon.addClass('opened');
			leftPart.addClass('opened');
			rightPart.addClass('opened');
		}
		setTimeout(function(){jQuery('#ripple').ripples('updateSize');},101);
		setTimeout(function(){jQuery('#ripple').ripples('updateSize');},201);
		setTimeout(function(){jQuery('#ripple').ripples('updateSize');},301);
		
		if(jQuery('.jarallax').length){
			jQuery('.jarallax').jarallax('destroy');
			setTimeout(function(){arlo_tm_jarallax();},300);
		
		}
		return false;
		
	});
	

}

function arlo_tm_data_images(){
	
	"use strict";
	
	var data			= jQuery('*[data-img-url]');
	
	data.each(function(){
		var element			= jQuery(this);
		var url				= element.data('img-url');
		element.css({backgroundImage: 'url('+url+')'});
	});
}

function arlo_tm_about_animation(){
		
		"use strict";
		
		if ($('.parallax').length > 0) { 
		  var scene = $('.parallax').get(0);
		  var parallax = new Parallax(scene, { 
			relativeInput: true,
			onReady: function() { console.log('ready!');
		  } });
		}
	}

function arlo_tm_hamburger(){
	
	"use strict";
	
	var hamburger 		= jQuery('.hamburger');
	var mobileMenu		= jQuery('.arlo_tm_mobile_menu_wrap');
	
	hamburger.on('click',function(){
		var element 	= jQuery(this);
		
		if(element.hasClass('is-active')){
			element.removeClass('is-active');
			mobileMenu.slideUp();
		}else{
			element.addClass('is-active');
			mobileMenu.slideDown();
		}
		return false;
	});
} 