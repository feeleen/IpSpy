# IpSpy
IpSpy runs as a service and sends email with external ip of a machine

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

install service with standard .net utilities:
sc.exe 

sc.exe create IpSpyService binpath= "C:\Path\To\IpSpy.exe"
