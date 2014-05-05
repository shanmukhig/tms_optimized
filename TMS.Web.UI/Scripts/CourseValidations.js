function validateCourse() {
  var i = true;
  i = i & validateInput('#Title', 'Course title required.', 'Course title should be a valid string.', 'left', stringRegEx);
  i = i & validateDD('#Status', 'Status required.', 'left');
  i = i & validateInput('#Price', 'Price required.', 'Price must be a positive integer.', 'left', intRegEx);
  i = i & validateInputO('#Description', 'Description must be a valid string.', 'left', stringRegEx);
  //i = i & validateTable('#Instructor', 'At least one instructor must be added to the course.', 'top', 3);
  i = i & validateTable('#coursesAdded', 'At least one topic must be added to the course.', 'top', 3);
  return i;
}