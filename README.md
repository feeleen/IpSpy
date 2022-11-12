# IpSpy
IpSpy runs as a service and sends email with external ip of a machine (if ip has changed).

The main purpose of this service is to know external/public ip of the remote pc, to be able to start it using WOL (wake on lan) feature or to connect to it via remote desktop.

Configuration is simple through appsettings.json file:
```
"IpSpy": {
        "IPProviderHost": "http://ipinfo.io/ip", //any web site that gives clean ip string only (https://icanhazip.com/, http://ipinfo.io/ip etc.)
        "CheckInterval": 5, //minutes
        "SMTP": {
            "Login": "mygmail@gmail.com",
            "Password": "pass",
            "Port": 1323,
            "Host": "smtp.gmail.com",
            "EnableSSL": "True"
        },
        "Email": {
            "To": "me@mail.com",
            "Subject": "my-ip",
            "BodyFormat": "{0}"
        }
    }
```


# Installation

install service with standard .net utilities

install with sc.exe:
```
sc create IpSpyService binpath= "C:\Path\To\IpSpy.exe" start= auto
```

and then

```
sc start IpSpyService
```
