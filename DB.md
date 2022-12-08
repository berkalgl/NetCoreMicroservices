Database Scaling
1) A - Atomicity 
		All or nothing
		If a query failed, none of it should is commited. We do not wanna leave the database in a state that is partial or not complete
   C - Correctness
		Valid to valid
		If we are doing something on a db, we shouldnt leave it in an invalid state. The data has to be correct at all times
   I - Isolation
		concurrent vs seperate
		any concurrent mutation or change on the database should be the same as if happened all seperately sequentially. Queries are essentially managed in isolation,so they dont affect each other.
   D - Durability
		Data reliability
		Database system should be reliable. We should not be in an instance, we lose data. Database crashes and is down
   
2) Single Database
	- Vertical Scaling
		Increasing Memory
		Better CPU
	- Optimized Queries in r/w operations
	- More optimized connection between application server and database

3) Multiple Databases - bad one
	1)
		- Multiple r/w database in this case
		- +n connections in app server
		- dedupe the data in the app server
	
	2) Manager/Worker model
		1) Manager receives the r/w actions and it is responsible for duplicating the data spreading worker databases
		2) LB balances the load on worker databases and worker databases go and backup data to the manager, manager propagate the data on other worker databases
			- Consistent reliablity layer is the manager.
			- eventually the worker database have the same data, and consistent both of instances
		
	3) Circle Manager/Worker model
		1) LB can distribute to any of worker/manager nodes, any single one of those nodes can act as a worker or manager
			- Eventual consistency vs strong consistency(Latency)
	
	4) Cache/Memory Cache Layer (Redis)
		1) On LB or application itself
			- We do not have to go to db
			
	5) Partitions (Vertical, row spliting or table)
		- Some slice of the data. Partition segments
		- We can simple slice data by table
		- We are creating more load for your databases to create those tables and joins from across partitions
		- Reading writing layer between these database distributed systems so then they could return that data individually(Db systems like this rethink db)
		
	6) Sharding (Horizontal)
		- With the sharding key, you will always have the same subset of the data.
		- LB (Nginx), go to appropiate db to retrive the data.
	
	7) Data centers
		- a data center for each region. It can have own scaling.
		
	8) Seperate r/w actions
		- we can seperate database with write read actions. Eventual consistency
		- we can choose different database systems
		- for read maybe elastic search for better reading
		- for write maybe cassandra for better writing 
		
	9) Saas...
	
	
	
NoSql vs Sql

1) Type
	Sql dbs are primarily called as relational db; whereas NoSql databases are primarily called as non relational or distributed

2) Language
	-Sql databases defines and manipulates data based structured query language (SQL). requires to use predefined schemas to determine the structure of your data before you work with.
	-A nosql database has dynamic schema for unstructured data. Data is stored in many ways which are document-oriented, column-oriented,graph-based or organized as a KeyValue store. 
	 Documents can be created without having defined structure first
	 
3) Scability
	-Most of sql dbs are vertically scalable by increasing resources.
	-but nosql databases are horizontally scalable easily. Sharding or adding more servers in your nosql databases.
	
4) Structure
	-Sql dbs are table-based, NoSql dbs are either key-value, document-based,graph databases or wide-column stores.
	-This makes relational sql dbs a better option for applications that require multirow transactions such as an accounting system or for legacy systems
	
5) Property followed
	-Sql dbs follow ACID properties (Atomicity, Consistency, Isolation and Durability) 
	-Nosql follows the Brewers CAP theorem (Consistency, Availability and Partition tolerance)

6) Support
	-Great support is available for all SQL database from their vendors. 
	-NoSql database you still have to rely on community support and only limited outside experts are available for setting up and deploying your large scale Nosql deployments