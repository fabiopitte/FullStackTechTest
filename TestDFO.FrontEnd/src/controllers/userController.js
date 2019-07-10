import '../views/user/list/index.css';
import '../views/user/create/index.css';
import '../views/user/update/index.css';

const userController = [
  '$scope',
  '$location',
  'userService',
  function($scope, $location, userService) {
    // get all users
    $scope.list = function() {
      const promisse = userService.list();

      promisse.then(function(response) {
        let users = [];
        response.data.map(u => {
          users.push(u);
        });

        $scope.users = users;
      });
    };

    // Get specific user by id
    $scope.get = function() {
      // workaroud because I dont remember how to get params for querystring :(
      const id = $location.path().split('/')[2];

      const promisse = userService.get(id);

      promisse
        .then(function(response) {
          if (response.data) {
            $scope.user = response.data;
          }
        })
        .catch(function(error) {
          console.log(error);
        });
    };

    // Create a user
    $scope.create = function() {
      const promisse = userService.create($scope.user);

      promisse
        .then(function(response) {
          if (response.status === 200) {
            console.info('User successfully created');
            $scope.successMessage = 'User created successfully';
            // successfully created, so redirect it to list view
          }
        })
        .catch(function(error) {
          console.log(error.data.title);
          $scope.errorMessage = error.data.title;
        });
    };

    // Update a user
    $scope.update = function() {
      const promisse = userService.update($scope.user);

      promisse
        .then(function(response) {
          if (response.status === 204) {
            console.info('User successfully updated');
            $scope.successMessage = 'User updated successfully';
            // successfully created, so redirect it to list view
          }
        })
        .catch(function(error) {
          console.log(error.data.title);
          $scope.errorMessage = error.data.title;
        });
    };

    $scope.saveform = function($event) {
      // checking data one by one if it's valid,
      // this because there are only 2 fields
      if (
        $event.user.name != '' &&
        $event.user.age != '' &&
        $event.user.age > 0
      ) {
        if ($event.user.id != null && $event.user.id != '') {
          this.update();
        } else {
          this.create();
        }
      }
    };
  }
];

export default userController;
