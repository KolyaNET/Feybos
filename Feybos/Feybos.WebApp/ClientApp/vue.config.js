var VueBuilder = require("vue-builder-webpack-plugin");

module.exports = {
	configureWebpack: {
		plugins: [
			new VueBuilder({
				path: "src"
			})
		]
	}
};