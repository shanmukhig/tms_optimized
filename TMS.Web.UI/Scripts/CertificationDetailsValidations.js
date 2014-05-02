$(document).ready(function () {
  setDateParams('#certDate', false);
  setDateParams('#expDate', false);
});

function validateCustom() {
  var i = true;
  i &= validateInput('#Title', 'Certificate title required.', 'Certificate title should be a valid string.', 'left', stringRegEx);
  i &= validateInput('#CertifyingCompany', 'Certifying company required.', 'Certifying company should be a valid string.', 'left', stringRegEx);
  i &= validateInput('#CertifiedDate', 'Certified date required.', '','left');
  i &= validateInput('#ValidThru', 'Expiration date required.', '','left');
  i &= validateInput('#Score', 'Score required.', 'Score should be a positive integer.', 'left', intRegEx);
  return i;
}
