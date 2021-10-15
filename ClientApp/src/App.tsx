import * as React from 'react';
import { Route } from 'react-router';
import Layout from './components/Layout';
import Home from './components/Home';
import Chat from './components/Chat';
import Video from './components/Video';
import Counter from './components/Counter';
import FetchData from './components/FetchData';

import Room from './pages/Room';
import Lobby from './pages/Lobby';

import './custom.css'

export default () => (
    <Layout>
        <Route exact path='/' component={Home} />
        <Route exact path='/room/:id' component={Room} />
        <Route path='/lobby' component={Lobby} />
        <Route path='/counter' component={Counter} />
        <Route path='/chat' component={Chat} />
        <Route path='/video' component={Video} />
        <Route path='/fetch-data/:startDateIndex?' component={FetchData} />
    </Layout>
);
