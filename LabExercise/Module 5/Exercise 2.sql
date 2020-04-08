
----------------Task 1: Add a Clustered Index to Sales.MediaOutlet ------------------

ALTER TABLE Sales.MediaOutlet ADD CONSTRAINT IX_MediaOutlet UNIQUE CLUSTERED (
MediaOutletID
);





---------------Task 2: Add a Clustered Index to Sales.PrintMediaPlacement------------	
CREATE UNIQUE CLUSTERED INDEX CIX_PrintMediaPlacement ON Sales.PrintMediaPlacement (
PrintMediaPlacementID ASC
);
