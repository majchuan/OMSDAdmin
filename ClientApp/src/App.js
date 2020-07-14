import React, { Component } from 'react';
import { Route, Redirect } from 'react-router';
import { Layout } from './components/Layout';
import Home from './components/Home';
import Clinic from './components/Clinic';
import ClinicHour from './components/ClinicHour';
import AddClinicHour from './components/AddClinicHour';
import Login from './components/Login';
import Registration from './components/Registration';
import User from './components/User';
import UserDetail from './components/UserDetail';
import { AuthService } from './service/AuthService';
import City from './components/City';
import CityDetail from './components/CityDetail';
import ServiceType from './components/ServiceType';
import ServiceTypeDetail from './components/ServiceTypeDetail';
import ExcelDownload from './components/ExcelDownload';


export default class App extends Component {
  displayName = App.name
    render() {

        const PrivateRoute = ({ component: Component, ...rest }) => (
            <Route {...rest} render={props =>
                AuthService.isAuth()
                    ? <Component {...props} />
                    : <Redirect to='/login' />
                } />
        );


        return (
            <Layout>
                <PrivateRoute exact path="/home/:page?" component={Home} />
                <PrivateRoute path="/clinic/:action?/:page?/:id?" component={Clinic} />
                <PrivateRoute path="/clinichour/:action?/:page?/:clinicID?" component={ClinicHour} />
                <PrivateRoute path='/user/:page?/:id?' component={User} />
                <PrivateRoute path='/userdetail/:action?/:id?' component={UserDetail} />
                <PrivateRoute path='/city/:page?/:id?' component={City} />
                <PrivateRoute path='/citydetail/:action?/:page?/:id?' component={CityDetail} />
                <PrivateRoute path='/servicetype/:page?/:id?' component={ServiceType} />
                <PrivateRoute path='/servicetypedetail/:action?/:page?/:id?' component={ServiceTypeDetail} />
                <PrivateRoute path='/download' component={ExcelDownload} />
                <Route exact path="/login" component={Login} />
                <Route path="/registration" component={Registration} />
            </Layout>
        );
  }
}
