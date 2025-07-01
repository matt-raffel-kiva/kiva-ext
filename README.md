# kiva Extensions
Tilt and docker extensions for the kiva build environment.

## Smtp Sink Service
The smtp sink is a simple SMTP server that accepts emails and writes them to a file. It is useful for testing email functionality in applications without sending real emails.
See the [doc](smtp-sink-service/README.md) for more information.

## Usage
1. Start kiva build environent
2. Start this extension enviroment using `tilt up --port 10351 --legacy`