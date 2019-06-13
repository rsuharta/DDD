Quick findings from event storming session:

>> The domain command in this task is Enrolling student to a subject, therefore this is Enrollment Bounded Context (BC)
>> Not sure why do we need CRUD for student and subject. It is not the responsiblity of this BC to have CRUD for student and subject. Ideally, there should be other microservice (Subject /and Course/Subject BC) which publishing SubjectRegistered / StudentRegistered Domain event in which this microservice listens to and register within its own data store.
>> Both lecture and lecture theater cannot live without a subject. Creation of a subject must include its lecture and theater information
>> Student can live without a subject (means the student is not being enrolled)
>> There are two aggregate objects within this BC, Student and Subject which leads to the API-first design to have 2 controllers for this two aggregate objects.
>> Student aggregate is responsible for 'enrolling in to subject' transaction
>> Subject aggregate is responsible for 'assigning/or re-assigning lecture/theater' transaction

Few things to do for production ready:
>> application looging
>> api documentations
>> implment exception filter middleware to catch and translate domain exception the appropaute http status code 
>> domain unit tests
>> acceptance tests
>> request validations
>> actual database storage (not only memory/ephemeral)
>> real implementation on Query side to read from replica storage
>> implement fault tolerance strategy with retry, circuit breaker, and fallback
>> nuget pkg generation for contract.csproj
