import React, { useState } from 'react';
import { Container, ButtonGroup, Button } from 'reactstrap';
import LoginForm from '../components/Forms/LoginForm';
import SignupForm from '../components/Forms/SignupForm';


function Signin() {
  const [login, setLogin] = useState(true);
  return (
    <Container className='m-auto border border-3 p-3 rounded' style={{ width: '400px' }}>
      <ButtonGroup className='w-100 mb-3'>
        <Button block active={login} onClick={() => setLogin(true)}>Log In</Button>
        <Button block active={!login} onClick={() => setLogin(false)}>Sign Up</Button>
      </ButtonGroup>
      {login ? <LoginForm /> : <SignupForm />}
    </Container>
  );
}


export default Signin;
