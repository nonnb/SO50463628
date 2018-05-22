CREATE TABLE participants 
(
	barcode bigint NOT NULL,
	event_id int NOT NULL,

	primary key(barcode, event_id)
);


CREATE TABLE prereg_participants 
(
	barcode bigint NOT NULL,
	event_id int NOT NULL,

	constraint fk_pp foreign key(barcode, event_id) references participants(barcode, event_id)
);

insert into participants(barcode, event_id) values (1, 1), (2, 2), (2, 1);
insert into prereg_participants(barcode, event_id) values (1, 1);

SELECT * FROM participants 
LEFT OUTER JOIN prereg_participants ON prereg_participants.barcode = participants.barcode
AND participants.event_id = prereg_participants.event_id
WHERE (participants.event_id = 1);

-- Which returns:
-- barcode              event_id    barcode              event_id
-- -------------------- ----------- -------------------- -----------
-- 1                    1           1                    1
-- 2                    1           NULL                 NULL