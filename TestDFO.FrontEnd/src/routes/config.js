const config = [
  '$routeProvider',
  '$locationProvider',
  function($routeProvider, $locationProvider) {
    $locationProvider.hashPrefix('');
    $locationProvider.html5Mode(true);

    $routeProvider
      .when('/user/create', {
        controller: 'userController',
        templateUrl: './src/views/user/create/index.html'
      })
      .when('/user', {
        controller: 'userController',
        templateUrl: './src/views/user/list/index.html'
      })
      .when('/user/:id', {
        controller: 'userController',
        templateUrl: './src/views/user/update/index.html'
      })
      .otherwise({
        redirectTo: '/'
      });
  }
];

export default config;
