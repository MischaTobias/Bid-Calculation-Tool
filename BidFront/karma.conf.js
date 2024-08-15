module.exports = function(config) {
  config.set({
    // Frameworks to use
    frameworks: ['jasmine', '@angular-devkit/build-angular'],

    // Files/patterns to load in the browser
    files: [
      // Include any files that you need to load before the tests run
    ],

    // Test results reporter to use
    reporters: ['progress', 'kjhtml'],

    // Web server port
    port: 9876,

    // Enable/disable colors in the output (reporters and logs)
    colors: true,

    // Level of logging
    logLevel: config.LOG_INFO,

    // Enable/disable watching file and executing tests whenever any file changes
    autoWatch: true,

    // Start these browsers
    browsers: ['Safari'],

    // Continuous Integration mode
    singleRun: false,

    // Concurrency level (how many browser should be started simultaneous)
    concurrency: Infinity,

    // List of plugins to load
    plugins: [
      require('karma-jasmine'),
      require('karma-safari-launcher'),
      require('karma-jasmine-html-reporter'),
      require('karma-coverage-istanbul-reporter'),
      require('@angular-devkit/build-angular/plugins/karma')
    ],

    // Coverage reporter configuration
    coverageIstanbulReporter: {
      dir: require('path').join(__dirname, './coverage'),
      reports: ['html', 'lcovonly', 'text-summary'],
      fixWebpackSourcePaths: true
    },

    // Custom launcher configuration (if needed)
    customLaunchers: {
      SafariCustom: {
        base: 'Safari',
      }
    }
  });
};
