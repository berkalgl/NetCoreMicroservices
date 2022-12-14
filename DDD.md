DDD

1 - Strategic Design
	what ? why ?
	event storming, big picture
	
	subdomain types
	- Core
	- Supporting
	- Generic
	
	Relation between subdomains, that is why we have context map.
	Ideally, each subdomain is mapped to a single bounded context
	bounded context is a logical boundary in which the terms are consistent
	language in a bounded context is referred to as its ubiquitous language.
	Most important concept in DDD, since it allows everyone to speak in same language
	and the terms in the code are the same terms used to talk to the business experts.
	
2 - Tactical Design
	how ?, solution scope
	Domain entity, domain price-value object
	Entity has id and mutable
	Price-value object doesnt have an id and is immutable
	Entities are equal if they have the same id eventhough they do not have the same values
	Value objects are equal if the values of the properties are equal
	
	Entities and value object consistent, they called aggregate
	Jam Aggregate
	Aggregate is always in a valid state
	is also transactional boundary means that any changes to it are either committed or rolled back as a whole