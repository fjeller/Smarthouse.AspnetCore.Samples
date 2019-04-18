const gulp = require('gulp');
const concat = require('gulp-concat');
const minify = require('gulp-csso');
const less = require('gulp-less');


function convertCss() {
    return gulp.src('wwwroot/less/*.less')
        .pipe(concat('site.css'))
        .pipe(less())
    .pipe(minify())
        .pipe(gulp.dest('wwwroot/css'));
}

exports.convert = convertCss;