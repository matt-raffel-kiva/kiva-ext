# smtp-sink

Provides an smtp sink service for testing email generation without changes to the implementation
consuming SMTP services (other than configuring it).

## Code

This project is early prototype code and has a lot of lingering code from ideas/experiments that were not fully realized. The goal of this project is to provide a simple smtp sink service that can be used to test email server services without having to change the implementation.

The reason C# was chosen was simply for the speed of building a service using robust packages with proven technologies. Rust,
GoLang and PHP were evaluated, but the time to build a simple service was longer than desired.  The goal of this project is to
provide a quick and simple smtp sink service that can be used to test email server services without having to change the implementation
consuming SMTP services (other than configuring it).

## Building and Running

1. clone the repo
2. run dotnet restore in the src directory
3. run dotnet build in the src directory
4. run `dotnet run --project SmtpSink/SmtpSink.csproj` in the src directory

## Integrating with Tilt

1. After getting kiva environment running and this extension environment running. See the [porject documentation](../../../README.md) for more information on that.
2. Add sendmail to the kiva utility pod: `apt update && apt install -y sendmail`
4. Test by running: ` swaks --to myemail@kiva.org --from test@localhost --server localhost:2525 --data "Subject: Test Email\n\nThis is a test email."`










