The "/wwwroot/info/" directory stores the raw data that will populate the web application.

"*.txt" files store "{key}={value}" lines.
  For example:
    Name=John
    AboutMe=I'm a person.

The "/wwwroot/info/" directory
  MUST contain "aboutme.txt"
    with the keys: Name,AboutMe
  MUST contain "contact.txt"
    with the keys: Number,Email
  MAY contain "resume.pdf"
  MAY contain "/projects/" directory

The "/wwwroot/info/projects/" directory
  MAY contain ANY "*.txt" 
    with the keys: Name,Description,MadeWith,SourceLink,ReleaseLink,Asset

$"MadeWith" key should be a list of materials used to make the project, separated by commas (e.g. Java,Swift,SQLite)
$"Asset" key should be the relative filepath (starting in /wwwroot/assets/) to a demonstration (.png, .webm) of the project

written by Andrew Pepin (andrewkpepin@gmail.com)