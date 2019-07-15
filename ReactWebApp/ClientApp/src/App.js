import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { MapNavigation } from './components/MapNavigation';

export default class App extends Component {
  displayName = App.name

  render() {
      return (
          <Layout>
            <Route exact path='/' component={MapNavigation} />
          </Layout>
    );
  }
}
