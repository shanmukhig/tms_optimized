function validateLead() {
  var i = true;
  i = i & validateDD('#Salutation', 'Salutation required.', 'left');
  i = i & validateInput('#FirstName', 'First name required.', 'First name should be valid.', 'left', stringRegEx);
  i = i & validateInput('#LastName', 'Last name required.', 'Last name should be valid.', 'left', stringRegEx);
  i = i & validateDD('#LeadType', 'Lead type required.', 'left');
  i = i & validateDD('#LeadSource', 'Lead source required.', 'left');
  i = i & validateDD('#ClientStatus', 'Client status required.', 'left');
  i = i & validateDD('#Status', 'Status required.', 'left');
  i = i & validateInput('#City', 'City required.', 'City should be valid.', 'left', stringRegEx);
  i = i & validateDD('#Country', 'Country required.', 'left');
  i = i & (validateTable('#communicationDetail', 'Communication detail required.', 'top', 3) && validatePreferred());
  i = i & validateTable('#bestTimetoContact', 'Best time to contact required.', 'top', 2);
  i = i & validateTable('#courseRequired', 'Course detail required.', 'top', 3);
  return i;
}

function validatePreferred() {
  var i = false;
  if ($('#communicationDetail tr td span i.fa-check-square').length <= 0)
    showPopover('#communicationDetail', 'Preferred communication type required.');
  else {
    removePopover('#communicationDetail');
    i = true;
  }
  return i;
}
