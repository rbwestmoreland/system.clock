System.Clock
===
A testable alternative to DateTime.Now

[![Build status](https://ci.appveyor.com/api/projects/status/t6qewtc12ivm2btu)](https://ci.appveyor.com/project/rbwestmoreland/system-clock)


Quick Start
---
    PM> Install-Package System.Clock

Now use `System.Clock.Now` instead of `System.DateTime.Now`

Examples
---

```csharp
//freeze time
System.Clock.Freeze(); 

//freeze at a specific time
System.Clock.Freeze(new DateTime(2012, 12, 21)); 

//return time to the present
System.Clock.Unfreeze(); 
```

Inspired by Ayende Rahien's [SystemTime](http://ayende.com/blog/3408/dealing-with-time-in-tests)
