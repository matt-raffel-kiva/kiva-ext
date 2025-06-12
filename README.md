# kiva-ext
Tilt and docker extensions for the kiva build environment.

## Smtp Sink
The smtp sink is a simple SMTP server that accepts emails and writes them to a file. It is useful for testing email functionality in applications without sending real emails.

## Usage
1. Start kiva build environent
2. Start this enviroment using `tilt up --port 10351 --legacy`