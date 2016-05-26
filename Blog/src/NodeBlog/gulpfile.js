/// <binding AfterBuild='moveToLibs' />
var gulp = require('gulp');
var shell = require('gulp-shell');

gulp.task('moveToLibs', function (done) {
    gulp.src([
      'node_modules/angular2/bundles/js',
      'node_modules/angular2/bundles/angular2.*.js*',
      'node_modules/angular2/bundles/angular2-polyfills.js',
      'node_modules/angular2/bundles/http.*.js*',
      'node_modules/angular2/bundles/router.*.js*',
      'node_modules/es6-shim/es6-shim.min.js*',
      'node_modules/angular2/es6/dev/src/testing/shims_for_IE.js',
      'node_modules/systemjs/dist/*.*',
      'bower_components/jquery/dist/jquery.*js',
      'bower_components/bootstrap/dist/js/bootstrap*.js',
      'bower_components/oidc-token-manager/dist/oidc-token-manager.js',
      'node_modules/rxjs/bundles/Rx.js'
    ]).pipe(gulp.dest('./wwwroot/libs/'));

    gulp.src([
      'bower_components/bootstrap/dist/css/bootstrap.css'
    ]).pipe(gulp.dest('./wwwroot/libs/css'));
});

gulp.task('typings', shell.task([
    'typings install'
]));