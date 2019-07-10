import CONFIGS from '../constants/constant';

const userService = [
  '$http',
  function($http) {
    this.list = function() {
      return $http.get(`${CONFIGS.baseServiceUrl}user`);
    };

    this.get = function(id) {
      return $http.get(`${CONFIGS.baseServiceUrl}user/${id}`);
    };

    this.create = function(user) {
      console.log(`${CONFIGS.baseServiceUrl}user`, user);

      return $http.post(`${CONFIGS.baseServiceUrl}user`, user);
    };

    this.update = function(user) {
      return $http.put(`${CONFIGS.baseServiceUrl}user/${user.id}`, user);
    };
  }
];

export default userService;
