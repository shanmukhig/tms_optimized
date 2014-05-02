function validateInstructor() {
  var i = true;
  i = i & validateDD('#Salutation', 'Salutation required.', 'left');
  i = i & validateInput('#FirstName', 'First name required.', 'First name should be valid.', 'left', stringRegEx);
  i = i & validateInput('#LastName', 'Last name required.', 'Last name should be valid.', 'left', stringRegEx);
  i = i & validateInput('#Experience', 'Experience required.', 'Experience must be a positive number.', 'left', numberRegEx);
  i = i & validateDD('#InstructorType', 'Instructor type required.', 'left');
  i = i & validateInput('#DateofJoin', 'Date of Join required.', '', 'left');
  i = i & validateDD('#Status', 'Status required.', 'left');
  i = i & validateInput('#City', 'City required.', 'City should be a valid string.', 'left', stringRegEx);
  i = i & validateDD('#Country', 'Country required.', 'left');
  i = i & (validateTable('#communicationDetail', 'Communication detail required.', 'top', 3) && validatePreferred());
  i = i & validateDD('#Status', 'Instructor status required.', 'left');
  i = i & validateInputO('#Description', 'Description should be a valid string.', '', 'top');
  i = i & validateTable('#courseDetail', 'Communication detail required.', 'top', 3);
  i = i & validateTable('#certifications', 'Communication detail required.', 'top', 3);
  i = i & validateRating();
  return i;
}

function validateRating() {
  var i = false;
  if ($('#Rating').find('i.fa-star-o').length == 5)
    showPopover('#Rating', 'Rating required', 'left');
  else {
    removePopover('#Rating');
    i = true;
  }
  return i;
}

