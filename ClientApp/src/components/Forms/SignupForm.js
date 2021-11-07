import React from 'react';
import { Form, FormGroup, FormText, Input, Label, Button } from 'reactstrap';


function SignupForm() {
  return (
    <Form>
      <FormGroup>
        <Label for='exampleInputUsername'>Username</Label>
        <Input id='exampleInputUsername' type='text'/>
      </FormGroup>
      <FormGroup>
        <Label for='exampleInputEmail'>Email address</Label>
        <Input id='exampleInputEmail' type='email'/>
        <FormText>We'll never share your email with anyone else.</FormText>
      </FormGroup>
      <FormGroup>
        <Label for='exampleInputPassword'>Password</Label>
        <Input id='exampleInputPassword' type='password'/>
      </FormGroup>
      <FormGroup check>
        <Input id='exampleCheck' type='checkbox'/>
        <Label for='exampleCheck' check>Check me out</Label>
      </FormGroup>
      <Button block color='primary'>Submit</Button>
    </Form>
  );
}

export default SignupForm;