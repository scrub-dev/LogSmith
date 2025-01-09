# Tags

LogSmith uses Mustache-style template tag also known as variable interpolation tags to produce logs of a known shape for testing.
Create a template string that LogSmith will then use to create Log entries with.

Available tags can also be customised with parameters to shape their output into the format you are looking for.

An example template string might look like:
```
{{date hh:mm:ss}} - {{loglevel}} : {{loremipsum (2,8)}}
```
Would produce: 
```
12:32:55 - WARN : Lorem Ipsum dolor
```


## Available Tags:
Tags typically follow an all lowercase paradigm except for parameters.
### date
Possible Parameters:
Any valid iso data format
example: `yyyy-MM-dd hh:mm:ss`

### loglevel
Possible Parameters:
blank: random log levels from warn/error/info/log
(K1:V1, K2,V2) : K = Log Level, V = chance of being used.
example `(WARN:20, LOG:80)`

### loremipsum
Possible Parameters:
N = n = any number, will return this many words from Lorem Ipsum Text
(N,M) = will pick a random amount of lorem upsum text to return between the two values N and M.
blank: random amount returned from 0 to length of lorum ipsum text.
