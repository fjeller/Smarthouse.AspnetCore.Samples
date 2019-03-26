const { watch, src, dest, parallel }  = require( 'gulp' );
const less = require( 'gulp-less' );
const concat = require( 'gulp-concat' );
const minify = require( 'gulp-csso' );
const uglify = require('gulp-uglify');


function css() {
	return src('wwwroot/less/*.less')
		.pipe(concat('site.css'))
		.pipe(less())
		.pipe(dest('wwwroot/css'));
}

function cssMinified() {
	return src( 'wwwroot/less/*.less' )
		.pipe( concat( 'site.min.css' ) )
		.pipe( less() )
		.pipe( minify() )
		.pipe( dest( 'wwwroot/css' ) );
}

function javascript() {
	return src( 'wwwroot/js/site.*.js', '!wwwroot/js/site.js', '!wwwroot/js/site.min.js' )
		.pipe( concat( 'site.js' ) )
		.pipe( dest( 'wwwroot/js' ) );
}

function javascriptMinified() {
	return src( 'wwwroot/js/site.*.js', '!wwwroot/js/site.js', '!wwwroot/js/site.min.js')
		.pipe(concat('site.min.js'))
		.pipe(uglify())
		.pipe(dest('wwwroot/js'));
}

var watcher = null;

function startWatcher(callback) {
	watcher = watch( 'wwwroot/less/*.less', parallel( css, cssMinified ) );
	callback();
}


exports.buildCss = css;
exports.buildCssMinified = cssMinified;
exports.javascript = javascript;
exports.javascriptMinified = javascriptMinified;
exports.startWatcher = startWatcher;





