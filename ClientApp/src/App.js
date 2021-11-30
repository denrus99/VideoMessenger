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
        {/*<Layout>*/}
          <Main/>
        {/*</Layout>*/}
      </Suspense>
    </Router>
  );
}


export default App;
