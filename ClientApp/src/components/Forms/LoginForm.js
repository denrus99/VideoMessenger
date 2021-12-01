import React from 'react';
import { Form, FormGroup, FormText, Input, Label, Button } from 'reactstrap';


function LoginForm() {
  return (
      <Form method="POST" action="auth" asp-anti-forgery="false">
      <div class="validation" asp-validation-summary="ModelOnly"></div>
      <FormGroup>
        <Label for='EmailAddress'>Email address</Label>
        <Input id='EmailAddress' type='email' name="EmailAddress"/>
        <FormText>We'll never share your email with anyone else.</FormText>
      </FormGroup>
      <FormGroup>
        <Label for='Password'>Password</Label>
        <Input id='Password' type='password' name="Password"/>
      </FormGroup>
      <FormGroup check>
        <Input id='exampleCheck' type='checkbox'/>
        <Label for='exampleCheck' check>Check me out</Label>
      </FormGroup>
      <Button block color='primary'>Submit</Button>
    </Form>
  );
}

export default LoginForm;