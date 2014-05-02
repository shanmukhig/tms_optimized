$(document).ready(function () {
  setDateParams('#dtBestTimeToContact', true);
});

function validateCustom() {
  return validateInput('#BestTimeToContact', 'Date time required.');
}