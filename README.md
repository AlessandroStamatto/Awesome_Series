# Awesome Series
Author: Alessandro Stamatto. 

A small Xamarin application that uses The Movie Database API to show Series info.

Search bar not fully implemented yet.

It uses:
+ Autofac: A dependency manager, used for registering Services and to add mappings from View to ViewModel. Also used for storing the Refit Interface to The Movie Database API as a service. 
+ Refit: Transforms an API into an interface (Refit uses decorators for automatically implement the requests, responses, and JSON parsing from the response). 
+ Xamarin.Forms: Allows writing the Graphical Interface (Views) in a Cross-Platform way.
