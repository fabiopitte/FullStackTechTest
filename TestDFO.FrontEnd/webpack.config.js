const webpack = require('webpack');
const path = require('path');
const HtmlWebpackPlugin = require('html-webpack-plugin');

module.exports = env => {
  return {
    entry: './src/app.js',
    output: {
      path: path.resolve(__dirname, 'build'),
      publicPath: '/',
      filename: 'bundle.js'
    },
    module: {
      rules: [
        {
          test: /(\.css)$/,
          use: ['style-loader', 'css-loader']
        }
      ]
    },
    plugins: [
      new webpack.ProgressPlugin(),
      new HtmlWebpackPlugin({
        template: 'index.html',
        favicon: 'src/favicon.ico'
      })
    ],
    devtool: 'source-map',
    devServer: {
      compress: true,
      contentBase: './',
      port: 9000,
      proxy: {
        '/api': 'https://localhost:44374/api/',
        secure: false
      }
    }
  };
};
