const gulp = require("gulp");
const less = require("gulp-less");
const minify = require("gulp-csso");
const concat = require("gulp-concat");


function buildCss() {
    return gulp.src("wwwroot/less/*.less")
        .pipe(concat("test.css"))
        .pipe(less())
        .pipe(gulp.dest("wwwroot/css"));
}

function buildCssMinified() {
    return gulp.src("wwwroot/less/*.less")
        .pipe(concat("test.min.css"))
        .pipe(less())
        .pipe(minify())
        .pipe(gulp.dest("wwwroot/css"));
}


exports.buildCss = buildCss;
exports.minify = buildCssMinified;