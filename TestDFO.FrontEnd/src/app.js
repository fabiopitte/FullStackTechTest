import angular from 'angular';
import * as _ from 'angular-route';

import config from './routes/config';
import userController from './controllers/userController';
import userService from './services/user-service';

import './main.css';

const app = angular
  .module('appTestDFO', ['ngRoute'])
  .config(config)
  .service('userService', userService)
  .controller('userController', userController);

export default app;
