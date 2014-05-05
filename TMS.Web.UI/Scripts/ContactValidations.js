function validateContact() {
  var i = true;
  i = i & validateDD('#Salutation', 'Salutation required.', 'left');
  i = i & validateInput('#FirstName', 'First name required.', 'First name should be valid.', 'left', stringRegEx);
  i = i & validateInput('#LastName', 'Last name required.', 'Last name should be valid.', 'left', stringRegEx);
  i = i & validateInput('#Title', 'Title required.', 'Title must be valid.', 'left', stringRegEx);
  i = i & validateInput('#CompanyName', 'Company name required.', 'Company name must be valid.', 'left', stringRegEx);
  i = i & validateInput('#State', 'State required.', 'State must be valid.', 'left', stringRegEx);
  i = i & validateInput('#Zip', 'Zip required.', 'Zip must be valid.', 'left', alphaNumericRegex);
  i = i & validateDD('#Status', 'Status required.', 'left');
  i = i & validateInput('#City', 'City required.', 'City should be valid.', 'left', stringRegEx);
  i = i & validateDD('#Country', 'Country required.', 'left');
  i = i & (validateTable('#communicationDetail', 'Communication detail required.', 'top', 3) && validatePreferred());
  i = i & validateInputO('#Description', 'Description must be valid.', 'left', stringRegEx);
  //i = i & validateTable('#courseRequired', 'Course detail required.', 'top', 3);
  return i;
}


