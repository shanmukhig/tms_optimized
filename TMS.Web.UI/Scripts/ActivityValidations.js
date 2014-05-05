function validateActivity() {
  var i = true;
  //i = i & validateDD('#AssignedTo', 'Assigned to required.', 'left');
  i = i & validateInput('#DueBy', 'Due by required.', '', 'left');
  i = i & validateDD('#Priority', 'Priority required.', 'left');
  i = i & validateDD('#ActivityStatus', 'Activity Status required.', 'left');
  i = i & validateDD('#ActivityType', 'Activity type required.', 'left');
  i = i & validateDD('#Status', 'Status required.', 'left');
  i = i & validateInputO('#Notes', 'Notes must be valid.', 'left', stringRegEx);
  return i;
}
