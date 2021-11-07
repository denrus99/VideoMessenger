import React, { Suspense } from 'react';
import { BrowserRouter as Router, Switch, Route } from 'react-router-dom';

import Layout from './components/Layout/Layout';
import Loading from './components/Loading'
import Video from './components/Video';
import Chat from './components/Chat';
import Room from './pages/Room';
import Lobby from './pages/Lobby';
import Signin from './pages/Signin'
import About from './pages/About'
import Home from './pages/Home'
import Main from './pages/Main';

function App() {
  return (
    <Router>
      <Suspense fallback={<Loading />}>
        <Layout>
          <Rouiting />
        </Layout>
      </Suspense>
    </Router>
  );
}

const Rouiting = () => {
  return (
    <Switch>
      <Route exact path='/' component={Home} />
      <Route path='/about' component={About} />
      <Route path='/signin' exact component={Signin} />
      <Route exact path='/room/:id' component={Room} />
      <Route path='/lobby' component={Lobby} />
      <Route path='/chat' component={Chat} />
      <Route path='/video' component={Video} />
      <Route path='/main' component={Main} />
    </Switch >
  );
}


export default App;
