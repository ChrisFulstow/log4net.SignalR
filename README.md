#log4net.SignalR
## Log4Net Appender for sending log events from server to browser

**log4net.SignalR** is a [Log4Net Appender](http://logging.apache.org/log4net/release/manual/introduction.html#appenders) that sends Log4Net events logged on the server to a JavaScript function in the browser.  It uses the [SignalR](https://github.com/SignalR/SignalR) async signaling library to stream these events in real-time over a persistent connection between the server and client.

The main use case for log4net.SignalR is building a log viewer on your site that gives easy visibility to diagnostic information and errors logged on the server.  (However, you probably won't want to use it in production in case your logs include sensitive information.)

###Feedback

Questions or feedback? Tweet me: [@ChrisFulstow](http://twitter.com/#!/ChrisFulstow)

##Getting started

Getting started is easy.  You can also check out the bundled MvcExample project to see some examples.

###Add log4net.SignalR.dll

Add the compiled log4net.SignalR.dll assembly or the source files to your project.

###Configure log4net.SignalR as a Log4Net appender

Configure the SignalrAppender as an output destination for your log events by adding this to web.config:

```xml
<configSections>
  <section name="log4net" type="log4net.Config.Log4NetConfigurationSectionHandler, log4net" />
</configSections>

<log4net debug="true">
    <appender name="SignalrAppender" type="log4net.SignalR.SignalrAppender">
        <layout type="log4net.Layout.PatternLayout">
            <conversionPattern value="%date %-5level - %message%newline" />
        </layout>
    </appender>
    <root>
        <appender-ref ref="SignalrAppender" />
    </root>
</log4net>
```

###Set up a page to listen for events

Add some jQuery to your ASP.NET page to listen out for events raised on the server.  Once the SignalrAppender is set up, all events logged on the server using Log4Net will be transmitted to the browser by executing a JavaScript function.

Here we're adding each event's details to an HTML table, but you can use the `onLoggedEvent` callback and the log details passed in the `loggedEvent` parameter object to do anything you like.

```javascript
    $(function () {
        var log4net = $.connection.signalrAppenderHub;

        log4net.onLoggedEvent = function (loggedEvent) {
            var dateCell = $("<td>").css("white-space", "nowrap").text(loggedEvent.TimeStamp);
            var levelCell = $("<td>").text(loggedEvent.Level);
            var detailsCell = $("<td>").text(loggedEvent.Message);
            var row = $("<tr>").append(dateCell, levelCell, detailsCell);
            $('#log-table tbody').append(row);
        };

        $.connection.hub.start(function () {
            log4net.listen();
        });
    });
```

##License
log4net.SignalR is open source under the [The MIT License (MIT)](http://www.opensource.org/licenses/mit-license.php)
