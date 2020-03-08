USE TestSQL;

-- Select users whose id is either 3,2 or 4--
-- Please return at least: all user fields--
SELECT id AS ID, CONCAT(first_name," " ,last_name) AS Name, email AS EMAIL, status AS STATUS, created AS 'CREATED ON'
 FROM Users 
 WHERE id IN (2,3,4);
 
 -- Count how many basic and premium listings each active user has--
-- Please return at least: first_name, last_name, basic, premium--
 SELECT u.id, CONCAT(u.first_name," " ,u.last_name) AS Name, count(distinct basic.id) AS BASIC_COUNT, count(distinct premium.id) AS PREMIUM_COUNT
FROM users u
LEFT JOIN listings basic
ON u.id = basic.user_id AND basic.status = 2
LEFT JOIN listings premium
ON u.id = premium.user_id AND premium.status = 3
WHERE u.status = 2
GROUP BY u.id;

-- Show the same count as before but only if they have at least ONE premium listing--
-- Please return at least: first_name, last_name, basic, premium--
SELECT u.first_name, u.last_name, count(distinct basic.id) AS BASIC_COUNT, count(distinct premium.id) AS PREMIUM_COUNT
FROM users u
LEFT JOIN listings basic
ON u.id = basic.user_id AND basic.status = 2 JOIN listings premium
ON u.id = premium.user_id AND premium.status = 3
WHERE u.status = 2
GROUP BY u.id;

 -- How much revenue has each active vendor made in 2013
--  Please return at least: first_name, last_name, currency, revenue--
SELECT users.first_name, users.last_name, clicks.currency, sum(clicks.price) AS revenue
FROM users users
LEFT JOIN listings listings
ON users.id = listings.user_id AND users.status = 2
LEFT JOIN clicks clicks
ON clicks.listing_id = listings.id
WHERE YEAR(clicks.created) = '2013'
GROUP BY users.id;


-- Insert a new click for listing id 3, at $4.00--
-- Find out the id of this new click. Please return at least: id--
INSERT INTO clicks(listing_id, price, currency, created) VALUES (3, 4.00,'USD', NOW()); 

SELECT * FROM clicks where id = LAST_INSERT_ID();

-- Show listings that have not received a click in 2013--
-- Please return at least: listing_name--
SELECT DISTINCT(listings.name)
FROM listings listings
LEFT JOIN clicks c
ON c.listing_id = listings.id
WHERE c.listing_id IS NULL OR YEAR(c.created) > '2013' AND YEAR(c.created) < '2013';


-- For each year show number of listings clicked and number of vendors who owned these listings --
-- Please return at least: date, total_listings_clicked, total_vendors_affected --
SELECT YEAR(c.created) AS DATE_YEAR, COUNT(c.id) AS total_listings_clicked, COUNT(distinct(u.id)) AS total_vendors_affected
FROM users u
INNER JOIN listings l
ON u.id = l.user_id
INNER JOIN clicks c
ON c.listing_id = l.id
GROUP BY DATE_YEAR;

-- Return a comma separated string of listing names for all active vendors --
-- Please return at least: first_name, last_name, listing_names --
SELECT u.id AS UserId, u.first_name, u.last_name, GROUP_CONCAT(l.name) AS listing_names
FROM users u
INNER JOIN listings l
ON u.id = l.user_id
WHERE u.status = 2
GROUP BY UserId