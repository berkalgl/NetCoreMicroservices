Rest API Methods
https://restfulapi.net/http-methods/
- GET 
	Retrieves data from the server. Should have no other effect.
	Use GET requests to retrieve resource representation/information only – and not modify it in any way. As GET requests do not change the resource’s state, these are said to be safe methods.
    Additionally, GET APIs should be idempotent. Making multiple identical requests must produce the same result every time until another API (POST or PUT) has changed the state of the resource on the server.
    If the Request-URI refers to a data-producing process, it is the produced data that shall be returned as the entity in the response and not the source text of the process, unless that text happens to be the output of the process.
	- Example URIs
		HTTP GET http://www.appdomain.com/users
		HTTP GET http://www.appdomain.com/users?size=20&page=5
		HTTP GET http://www.appdomain.com/users/123
		HTTP GET http://www.appdomain.com/users/123/address
	
- PUT
	Replaces target resource with the request payload. Can be used to update or create a new resource.

	Use PUT APIs primarily to update an existing resource (if the resource does not exist, then API may decide to create a new resource or not).
	
	If the request passes through a cache and the Request-URI identifies one or more currently cached entities, those entries SHOULD be treated as stale. Responses to PUT method are not cacheable.

	-PUT API Response Codes
	If a new resource has been created by the PUT API, the origin server MUST inform the user agent via the HTTP response code 201 (Created) response.
	If an existing resource is modified, either the 200 (OK) or 204 (No Content) response codes SHOULD be sent to indicate successful completion of the request.
	
	-Example URIs
	HTTP PUT http://www.appdomain.com/users/123
	HTTP PUT http://www.appdomain.com/users/123/accounts/456
	The difference between the POST and PUT APIs can be observed in request URIs. POST requests are made on resource collections, whereas PUT requests are made on a single resource.

- PATCH 
	Similar to PUT, but used to update only certain fields within an existing resource.

	HTTP PATCH requests are to make a partial update on a resource.

	If you see PUT requests modify a resource entity too. So to make it more precise – the PATCH method is the correct choice for partially updating an existing resource, and you should only use PUT if you’re replacing a resource in its entirety.

	Please note that there are some challenges if you decide to use PATCH APIs in your application:

	Support for PATCH in browsers, servers, and web application frameworks is not universal. IE8, PHP, Tomcat, Django, and lots of other software have missing or broken support for it.
		HTTP GET /users/1
	produces below response:

	{ "id": 1, "username": "admin", "email": "email@example.org"}
	A sample patch request to update the email will be like this:

	HTTP PATCH /users/1
	[{ "op": "replace", "path": "/email", "value": "new.email@example.org" }]
	There may be the following possible operations are per the HTTP specification.

	[
	{ "op": "test",  "path": "/a/b/c",  "value": "foo"  },
	{ "op": "remove",  "path": "/a/b/c"  },
	{ "op": "add",  "path": "/a/b/c",  "value": [ "foo", "bar" ] },
	{ "op": "replace", "path": "/a/b/c",  "value": 42 },
	{ "op": "move",  "from": "/a/b/c",  "path": "/a/b/d" },
	{ "op": "copy", "from": "/a/b/d",  "path": "/a/b/e" }
	]
	The PATCH method is not a replacement for the POST or PUT methods. It applies a delta (diff) rather than replacing the entire resource.

- POST
	Performs resource-specific processing on the payload. Can be used for different actions including creating a new resource, uploading a file, or submitting a web form.
	Use POST APIs to create new subordinate resources, e.g., a file is subordinate to a directory containing it or a row is subordinate to a database table.

	When talking strictly about REST, POST methods are used to create a new resource into the collection of resources.
	Responses to this method are not cacheable unless the response includes appropriate Cache-Control or Expires header fields.

	Please note that POST is neither safe nor idempotent, and invoking two identical POST requests will result in two different resources containing the same information (except resource ids).

	-POST API Response Codes
		Ideally, if a resource has been created on the origin server, the response SHOULD be HTTP response code 201 (Created) and contain an entity that describes the status of the request and refers to the new resource, and a Location header.
		Many times, the action performed by the POST method might not result in a resource that can be identified by a URI. In this case, either HTTP response code 200 (OK) or 204 (No Content) is the appropriate response status.

- DELETE
	As the name applies, DELETE APIs delete the resources (identified by the Request-URI).

	DELETE operations are idempotent. If you DELETE a resource, it’s removed from the collection of resources.

	Some may argue that it makes the DELETE method non-idempotent. It’s a matter of discussion and personal opinion.

	If the request passes through a cache and the Request-URI identifies one or more currently cached entities, those entries SHOULD be treated as stale. Responses to this method are not cacheable.

	-DELETE API Response Codes
	A successful response of DELETE requests SHOULD be an HTTP response code 200 (OK) if the response includes an entity describing the status.
	The status should be 202 (Accepted) if the action has been queued.
	The status should be 204 (No Content) if the action has been performed but the response does not include an entity.
	Repeatedly calling DELETE API on that resource will not change the outcome – however, calling DELETE on a resource a second time will return a 404 (NOT FOUND) since it was already removed.
	
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

- Glossary
	- Safe Methods
	Request methods are considered safe if their defined semantics are essentially read-only. The client does not request, and does not expect, any state change on the origin server as a result of applying a safe method to a target resource.

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
	
- Cacheable Principle
	The response has to be signed as cacheable if they are.
	
- Layered System Principle
	The relation between server and client can be multi-layered.
	
- Code On demand (Optional)
	Server can send additional data which extend client process and reduces the cost in client side
	JS file can be included in html file.