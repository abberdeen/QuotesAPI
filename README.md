# QuotesAPI
RESTful quotation management API with the following technical properties:
* Language of development C# on .NET Core 3.1
* JSON format is used to exchange data between the client and server
* For preserving user data and app state between requests used Dependency Injection.

## Table of contents

<!-- toc -->
- [Getting started](#getting-started)
- [Routes](#routes)
- [Worker service](#worker-service)
- [License](#license)
<!-- tocstop -->

## Getting started

## Routes

#### Create a quote with following fields: author, quote, category.
```
POST /api/quotes
```

#### Edit/Change quote: author, quote, category.
```
PUT /api/quotes/1
```

#### Delete a quote by ID.
```
DELETE /api/quotes/1
```

#### Get all quotes.
```
GET /api/quotes
```

#### Get all quotes by category.
```
GET /api/quotes/category/abc
```

#### Get a random quote.
```
GET /api/quotes/random
```
## Worker service

### QuotesWS
Worker that wakes up every 5 minutes and deletes quotes that were created more than 1 hour ago.


## License
MIT
