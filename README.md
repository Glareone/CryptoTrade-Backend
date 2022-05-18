# CryptoTrade-Backend

This is the Backend API part of CryptoTrade platform.

Should support next things:  
&#9744; Provide anonymous access for several endpoints.  
&#9744; Provide protected access for others.  
&#9744; Integration with Authentication Provider (Most likely will be Okta)  
&#9744; Integration with Authorization Provider   
&#9745; Supports CQRS  
&#9745; Supports Mapping  
&#9744; Entity Framework   

## CQRS
We are going to use CQRS to split sources for reading.
Also we want to support writing operations for Admin and it means better to split completely this operations.