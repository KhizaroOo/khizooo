
$(document).ready(function () {

	let presets = window.localStorage.getItem('presets');
	let colorPresets = { custom: [] };
	let gradientPresets = { custom: [] };

	// maybe override the built-in default presets as well
	/*
		colorPresets.defaults = ['red', 'blue'];
		gradientPresets.defaults = ['linear-gradient(white, black)', radial-gradient(red, blue)];
	*/

	if (presets) {
		try {
			presets = JSON.parse(presets);
		} catch (e) {
			presets = null;
		}
		if (presets) {
			const {
				colorPresets: customColors,
				gradientPresets: customGradients,
			} = presets;

			colorPresets.custom = customColors;
			gradientPresets.custom = customGradients;
		}
	}

	// callback for when custom presets are saved or deleted
	const onSaveDeletePreset = ({
		action, // "save" or "delete"
		groupChanged, // "color" or "gradient"
		colorPresets, // the current custom color presets array
		gradientPresets, // the current custom gradient presets array
	}) => {
		// or save to your databsase here
		window.localStorage.setItem('presets', JSON.stringify({
			colorPresets,
			gradientPresets,
		}));
	};

	// set the value of your input field when the color changes 
	// (the App DOES NOT write to your input field intentionally)
	const onColorChange = (input, color) => input.value = color;

	// initial call with custom settings
	window.advColorPicker({
		// "full" = all controls, "single" = only color controls (no gradients) -- default: "full"
		mode: 'full',

		// the size of the color picker swatches -- default: 24
		size: 24,

		// the color pickjer swatch skin, "classic" or "light" -- default: "classic"
		skin: 'classic',

		// optional color for the modal background -- default: "rgba(0,0,0,0.5)"
		modalBgColor: 'rgba(0,0,0,0.5)',

		// optional id attribute to to apply to the editor's outermost wrapper - default: null
		editorId: true,

		// allow multi-color stops in output -- default: true
		// multi-color stops allow for condensed output but are not supported in Edge
		multiStops: true,

		// allow conic gradients (only supported in webkit browsers) -- default: true
		conic: true,

		// show the default warning note for conic gradients (if conic is enabled) -- default: false
		conicNote: true,

		// show the bar at the bottom of the screen displaying the final output value -- default: false
		outputBar: true,

		// color change callback function (see above)
		onColorChange,

		// default and/or custom color presets: { defaults: [], custom: [] }
		colorPresets,

		// default and/or gradient presets: { defaults: [], custom: [] }
		gradientPresets,

		// save/delete preset callback function (see above)
		onSaveDeletePreset,
	});

	const pageContentChange = () => {
		const input = document.createElement('input');
		input.type = 'hidden';
		input.className = 'cj-colorpicker';
		input.value = 'green';
		document.body.appendChild(input);
		window.advColorPicker();
	};

	const input = document.querySelector('.cj-colorpicker');
	input.value = "linear-gradient(blue,red)";
	input.click();

});