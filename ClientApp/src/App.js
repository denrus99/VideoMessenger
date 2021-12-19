import React, { Suspense } from 'react';
import { BrowserRouter as Router } from 'react-router-dom';
import Loading from './components/Loading'
import Main from './components/Main/Main';


function App() {
  return (
    <Router>
      <Suspense fallback={<Loading />}>
          <Main/>
      </Suspense>
    </Router>
  );
}


export default App;
