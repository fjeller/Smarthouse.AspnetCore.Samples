const gulp = require('gulp');
//const { src, dest } = require('gulp');
const less = require('gulp-less');
const concat = require('gulp-concat');
const minify = require('gulp-csso');

function css() {
    return gulp.src('wwwroot/less/*.less')
        .pipe(concat('site.css'))
        .pipe(less())
        .pipe(gulp.dest('wwwroot/css'));
}

function cssMinified() {
    return gulp.src('wwwroot/less/**/*.less')
        .pipe(concat('site.min.css'))
        .pipe(less())
        .pipe(minify())
        .pipe(gulp.dest('wwwroot/css'));
}

exports.buildCss = css;
exports.minifyCss = cssMinified;
