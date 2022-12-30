Rest API Methods
- GET 
	Retrieves data from the server. Should have no other effect.
	
- PUT
	Replaces target resource with the request payload. Can be used to update or create a new resource.
	
- PATCH 
	Similar to PUT, but used to update only certain fields within an existing resource.

- POST
	Performs resource-specific processing on the payload. Can be used for different actions including creating a new resource, uploading a file, or submitting a web form.

- DELETE
	Removes data from the server.
	
- TRACE
	Provides a way to test what the server receives. It simply returns what was sent.
	
- OPTIONS
	Allows a client to get information about the request methods supported by a service. The relevant response header is Allow with supported methods. Also used in CORS as preflight request to inform the server about actual the request method and ask about custom headers.

- HEAD
	Returns only the response headers.

- CONNECT 
	Used by the browser when it knows it talks to a proxy and the final URI begins with https://. 
	The intent of CONNECT is to allow end-to-end encrypted TLS sessions, so the data is unreadable to a proxy.
	
Idempotency
- POST is NOT idempotent.
- GET, PUT, DELETE, HEAD, OPTIONS and TRACE are idempotent.

https://restfulapi.net/idempotent-rest-apis/
https://www.rfc-editor.org/rfc/rfc9110.html

Rest Principles

- Client-Server Principle
	Cliens and servers have to be seperated. They should not interupt each other areas.
	
- Uniform Interface Principle
	every request which is sent to same resource has to be replied as the same without client type.
	has four properties
	
	- Unique Resources
	- Client can change the data in the resource from server
	- Client and Server has to send every data they required.
	- HATEOAS / the response from the server can include other actions as well.(links/URIs)
	

- Statelessness Principle
	Every request is independent from each other and considered independently in server side.
	Server should not keep the data about auth token.
	The auth data has to be kept sending to the server.
	