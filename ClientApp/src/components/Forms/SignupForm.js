import React from 'react';
import { Form, FormGroup, FormText, Input, Label, Button } from 'reactstrap';


function SignupForm() {
    return (
      <Form method="POST" action="register" asp-anti-forgery="false">
      <div class="validation" asp-validation-summary="ModelOnly"></div>
      <FormGroup>
        <Label name='Login'>Login</Label>
        <Input id='Login' type='text' name="Login" />
        <FormText>We'll never share your login with anyone else.</FormText>
        <span asp-validation-for="Login" />
      </FormGroup>
      <FormGroup>
         <Label name='PhoneNumber'>PhoneNumber</Label>
         <Input id='PhoneNumber' type='text' name="PhoneNumber" />
         <FormText>We'll never share your PhoneNumber with anyone else.</FormText>
      </FormGroup>
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

export default SignupForm;