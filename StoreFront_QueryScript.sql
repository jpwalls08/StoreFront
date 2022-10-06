/****** Object:  StoredProcedure [dbo].[sprocFuzzySearch]    Script Date: 10/6/2022 3:37:41 PM ******/
DROP PROCEDURE IF EXISTS [dbo].[sprocFuzzySearch]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Equipment]') AND type in (N'U'))
ALTER TABLE [dbo].[Equipment] DROP CONSTRAINT IF EXISTS [FK_EquipmentStatuses_GolfStores]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Equipment]') AND type in (N'U'))
ALTER TABLE [dbo].[Equipment] DROP CONSTRAINT IF EXISTS [FK_Equipment_EquipmentTypes]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Equipment]') AND type in (N'U'))
ALTER TABLE [dbo].[Equipment] DROP CONSTRAINT IF EXISTS [FK_Equipment_EquipmentStatus]
GO
/****** Object:  Table [dbo].[GolfStores]    Script Date: 10/6/2022 3:37:41 PM ******/
DROP TABLE IF EXISTS [dbo].[GolfStores]
GO
/****** Object:  Table [dbo].[EquipmentTypes]    Script Date: 10/6/2022 3:37:41 PM ******/
DROP TABLE IF EXISTS [dbo].[EquipmentTypes]
GO
/****** Object:  Table [dbo].[EquipmentStatus]    Script Date: 10/6/2022 3:37:41 PM ******/
DROP TABLE IF EXISTS [dbo].[EquipmentStatus]
GO
/****** Object:  Table [dbo].[Equipment]    Script Date: 10/6/2022 3:37:41 PM ******/
DROP TABLE IF EXISTS [dbo].[Equipment]
GO
/****** Object:  Table [dbo].[Equipment]    Script Date: 10/6/2022 3:37:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Equipment](
	[EquipmentID] [int] IDENTITY(1,1) NOT NULL,
	[EquipmentName] [varchar](50) NOT NULL,
	[EquipmentPrice] [money] NOT NULL,
	[EquipmentDescription] [varchar](1500) NULL,
	[StoreID] [int] NULL,
	[EquipmentTypeID] [int] NULL,
	[StatusID] [int] NULL,
	[ProductImage] [varchar](100) NULL,
 CONSTRAINT [PK_EquipmentStatuses] PRIMARY KEY CLUSTERED 
(
	[EquipmentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EquipmentStatus]    Script Date: 10/6/2022 3:37:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EquipmentStatus](
	[StatusID] [int] IDENTITY(1,1) NOT NULL,
	[StatusName] [varchar](50) NOT NULL,
 CONSTRAINT [PK_EquipmentStatus] PRIMARY KEY CLUSTERED 
(
	[StatusID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EquipmentTypes]    Script Date: 10/6/2022 3:37:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EquipmentTypes](
	[EquipmentTypeID] [int] IDENTITY(1,1) NOT NULL,
	[TypeName] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Equipment] PRIMARY KEY CLUSTERED 
(
	[EquipmentTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GolfStores]    Script Date: 10/6/2022 3:37:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GolfStores](
	[StoreID] [int] IDENTITY(1,1) NOT NULL,
	[StoreName] [nvarchar](50) NOT NULL,
	[PhoneNumber] [varchar](50) NOT NULL,
	[Region] [varchar](20) NULL,
	[Country] [varchar](50) NULL,
	[ZipCode] [char](10) NULL,
	[State] [char](10) NULL,
	[Address] [nvarchar](50) NULL,
 CONSTRAINT [PK_GolfStores] PRIMARY KEY CLUSTERED 
(
	[StoreID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Equipment] ON 
GO
INSERT [dbo].[Equipment] ([EquipmentID], [EquipmentName], [EquipmentPrice], [EquipmentDescription], [StoreID], [EquipmentTypeID], [StatusID], [ProductImage]) VALUES (15, N'TaylorMade P790 Irons', 1299.0000, N'Players Iron
2022, Golf Digest Hot List Gold Winner, 
SpeedFoam Air
Thin-Wall Construction, 
Forged L-Face
, Thru-Slot Speed Pocket
, Intelligent Sweet Spot, 
Tungsten Weighting', 10, 1, 1, NULL)
GO
INSERT [dbo].[Equipment] ([EquipmentID], [EquipmentName], [EquipmentPrice], [EquipmentDescription], [StoreID], [EquipmentTypeID], [StatusID], [ProductImage]) VALUES (17, N'Ping i525 Irons', 1312.5000, N'Player''s Distance Iron
Variable Thickness Forged Face
Micromax Groove System
Players Style Design with Perimeter Weighting', 4, 1, 6, NULL)
GO
INSERT [dbo].[Equipment] ([EquipmentID], [EquipmentName], [EquipmentPrice], [EquipmentDescription], [StoreID], [EquipmentTypeID], [StatusID], [ProductImage]) VALUES (29, N'Ping G425 Irons', 1099.0000, N'Tungsten toe screw and hosel weight increase MOI and forgiveness. 
Metal-wood-style, variable-thickness for greater ball speed. Cascading sole and top-rail undercut increases flexing for longer, higher shots
. Multi-material cavity badge covers more face for excellent feel and sound. 
Hydropearl chrome finish repels water for improved performance in all conditions
. Medium-sized clubheads with lots of forgiving features while featuring a fairly classic profile at address.', 1, 1, 1, NULL)
GO
INSERT [dbo].[Equipment] ([EquipmentID], [EquipmentName], [EquipmentPrice], [EquipmentDescription], [StoreID], [EquipmentTypeID], [StatusID], [ProductImage]) VALUES (30, N'TaylorMade P770 Irons', 1224.9900, N'Compact players shape with thin topline, less offset and shorter blade length
AC1 Hollow Body Construction with thin, wrap around forged 4140 face, soft carbon steel body and tungsten weighting for distance and forgiveness
Speedfoam™ ultra-light urethane foam injected inside head for face speed and feel
Thru-slot Speed Pocket™ maximizes ball speeds and offers superior forgiveness
Progressive Inverted Cone Technology improves accuracy and protects off-center ball speed', 2, 1, 4, NULL)
GO
INSERT [dbo].[Equipment] ([EquipmentID], [EquipmentName], [EquipmentPrice], [EquipmentDescription], [StoreID], [EquipmentTypeID], [StatusID], [ProductImage]) VALUES (32, N'Titlieist T100 Irons', 1299.0000, N'Players Iron
2022 Golf Digest Hot List Gold Winner
Forged, dual cavity design
Tour contoured sole
D18 tungsten weighting
Tour inspired shape', 1, 1, 1, NULL)
GO
INSERT [dbo].[Equipment] ([EquipmentID], [EquipmentName], [EquipmentPrice], [EquipmentDescription], [StoreID], [EquipmentTypeID], [StatusID], [ProductImage]) VALUES (33, N'Callaway Rogue ST Irons', 999.9900, N'A forgiving game-improvement iron with high launch, wide soles, and enhanced offset for mid-high handicap golfers.', 10, 1, 5, NULL)
GO
INSERT [dbo].[Equipment] ([EquipmentID], [EquipmentName], [EquipmentPrice], [EquipmentDescription], [StoreID], [EquipmentTypeID], [StatusID], [ProductImage]) VALUES (35, N'Ping G410 3 Hybrid', 199.9900, N' An ideal long-iron replacement option when gapping your set for mid-to-long distance shots. Designed to provide hotter ball speeds and higher launch for stopping power on the green.', 2, 1, 1, NULL)
GO
INSERT [dbo].[Equipment] ([EquipmentID], [EquipmentName], [EquipmentPrice], [EquipmentDescription], [StoreID], [EquipmentTypeID], [StatusID], [ProductImage]) VALUES (36, N'Titliest TSR 2 Driver', 599.9900, N'Titleist TSR2 is slimmed down and ramped up. For players who make contact across the entire surface of the face, it combines our most significant CG shift with a new Multi-Plateau VFT face to boost speed across the face. All within a cleaner, refined shape that inspires total player confidence.', 1, 1, 6, NULL)
GO
INSERT [dbo].[Equipment] ([EquipmentID], [EquipmentName], [EquipmentPrice], [EquipmentDescription], [StoreID], [EquipmentTypeID], [StatusID], [ProductImage]) VALUES (37, N'Cobra LTDx ONE Irons', 899.9900, N'Designed at 7-iron length for enhanced consistency and accuracy from club to club
Traditionally, players have a different setup, ball position, and swing for every club in their bag which causes inconsistencies. ONE Length reduces as many variables as possible to promote one consistent setup, ball position, and swing through the set. The result is more accuracy, more consistency, and improved confidence', 4, 1, 1, NULL)
GO
INSERT [dbo].[Equipment] ([EquipmentID], [EquipmentName], [EquipmentPrice], [EquipmentDescription], [StoreID], [EquipmentTypeID], [StatusID], [ProductImage]) VALUES (38, N'Walter Hagen Men''s Perfect 11 Golf Shorts', 75.0000, N'Master your swing while sporting the look of a pro in the Walter Hagen® Men’s Perfect 11 Golf Shorts. Built for all-day wear, the shorts feature Hydro-Dri technology and 2-way stretch fabric to provide ultimate comfort every time you take the course.', 2, 2, 4, NULL)
GO
INSERT [dbo].[Equipment] ([EquipmentID], [EquipmentName], [EquipmentPrice], [EquipmentDescription], [StoreID], [EquipmentTypeID], [StatusID], [ProductImage]) VALUES (39, N'Nike Men''s Dri-FIT UV Chino 9" Golf Shorts', 68.0000, N'Standard fit for a relaxed, easy feel
Stretchy fabric for full range of motion
Zippered fly with button closure provides a secure fit
Two hand pockets and two back pockets for ample storage space
Tee pocket offers room to stash small items
Orange Nike® DNA label above the back right pocket
Waistband lined with chambray material for a classic look
Grippy stripe on the inside of the waistband to keep your shirt tucked in', 2, 2, 1, NULL)
GO
INSERT [dbo].[Equipment] ([EquipmentID], [EquipmentName], [EquipmentPrice], [EquipmentDescription], [StoreID], [EquipmentTypeID], [StatusID], [ProductImage]) VALUES (40, N'Adidas Women''s Warp Knit Golf Skirt', 80.0000, N'Regular fit with a mid rise
Wide waist with drawcord for adjustment
Supportive with a compressive feel from the undershorts
Two front zip pockets and two back zip pockets
Two side vents for breathability', 4, 2, 6, NULL)
GO
INSERT [dbo].[Equipment] ([EquipmentID], [EquipmentName], [EquipmentPrice], [EquipmentDescription], [StoreID], [EquipmentTypeID], [StatusID], [ProductImage]) VALUES (41, N'Lady Hagen Women''s Solid UV Long Sleeve Golf Dress', 23.9600, N'Regular fit golf dress
Clean finish collar
Coil zipper
Side seam pockets', 1, 2, 1, NULL)
GO
INSERT [dbo].[Equipment] ([EquipmentID], [EquipmentName], [EquipmentPrice], [EquipmentDescription], [StoreID], [EquipmentTypeID], [StatusID], [ProductImage]) VALUES (44, N'TravisMathew Men''s The Zinna Golf Polo', 84.9500, N'Standard fit short sleeve polo
Lightweight, premium-quality fabric for elevated style and performance
3-button placket offers easy adjustability
Self-fabric collar provides a course-ready look
TravisMathew® logo at left chest', 2, 2, 1, NULL)
GO
INSERT [dbo].[Equipment] ([EquipmentID], [EquipmentName], [EquipmentPrice], [EquipmentDescription], [StoreID], [EquipmentTypeID], [StatusID], [ProductImage]) VALUES (45, N'Titleist Men''s 2022 Tour Performance Golf Hat', 30.0000, N'Lightweight design
Structured front panel
Interior branding on taping
Performance material
Stretch clasp closure to adjust', 10, 2, 4, NULL)
GO
INSERT [dbo].[Equipment] ([EquipmentID], [EquipmentName], [EquipmentPrice], [EquipmentDescription], [StoreID], [EquipmentTypeID], [StatusID], [ProductImage]) VALUES (56, N'Ping Hoover Tour Bag', 370.0000, N'Inspired by our Tour Staff bag, the Hoofer Tour carry bag is organized and affords generous cargo space. A new back puck allows the dual padded straps to convert easily to a single, and the large apparel pocket has a full-length zipper for easier access. A magnetic quick-access pocket and two zippered, expandable water-bottle pockets are among 9 pockets altogether. With a roomy 5-way top.', 10, 3, 2, NULL)
GO
INSERT [dbo].[Equipment] ([EquipmentID], [EquipmentName], [EquipmentPrice], [EquipmentDescription], [StoreID], [EquipmentTypeID], [StatusID], [ProductImage]) VALUES (57, N'Titleist 2021 Players 4 Stand Bag', 225.0000, N'TOP: 4-Way
Lightweight, low profile top cuff with full-length dividers
7 pockets, including:
Quick-access magnetic accessories pocket
External water bottle pocket
Soft-touch valuables pocket
Full-length apparel pocket
High-grade aluminum legs and hinged bottom for stability
Premium double strap
Weight: 3.8 lbs.
Country of Origin : Imported
Weight : ~4 lb
Brand : Titleist', 1, 3, 1, NULL)
GO
INSERT [dbo].[Equipment] ([EquipmentID], [EquipmentName], [EquipmentPrice], [EquipmentDescription], [StoreID], [EquipmentTypeID], [StatusID], [ProductImage]) VALUES (58, N'Barstool Sports Fore Play Stand Bag', 230.0000, N'5-way divided top
5 pocket design
Comfort dual carrying strap
Rainhood included', 4, 3, 2, NULL)
GO
INSERT [dbo].[Equipment] ([EquipmentID], [EquipmentName], [EquipmentPrice], [EquipmentDescription], [StoreID], [EquipmentTypeID], [StatusID], [ProductImage]) VALUES (59, N'OGIO Fuse 4 Stand Bag', 190.9000, N'4-way Top with full length dividers
6 front facing pockets
Closed-cell foam molded double shoulder strap with Fit Disc self-balancing strap system', 2, 3, 6, NULL)
GO
INSERT [dbo].[Equipment] ([EquipmentID], [EquipmentName], [EquipmentPrice], [EquipmentDescription], [StoreID], [EquipmentTypeID], [StatusID], [ProductImage]) VALUES (61, N'Vessel VLS Stand Bag', 305.0000, N'4-way divided top
6 pocket design', 10, 3, 2, NULL)
GO
INSERT [dbo].[Equipment] ([EquipmentID], [EquipmentName], [EquipmentPrice], [EquipmentDescription], [StoreID], [EquipmentTypeID], [StatusID], [ProductImage]) VALUES (62, N'TaylorMade 2022 Vessel Lite Lux Stand Bag', 399.9900, N'Synthetic leather construction
Patented Rotator Stand System™ for maximum stability
Patented Equilibrium™ 2.0 Convertible strap
Dual-purpose bottle opener/towel ring
All-weather, matching rain hood
Umbrella holder
Pen holder
Ball pocket offers room for custom embroidery
Weight: 4.5 lbs
Country of Origin : Imported
Weight : ~4.5 lb
Brand : TaylorMade', 1, 3, 1, NULL)
GO
INSERT [dbo].[Equipment] ([EquipmentID], [EquipmentName], [EquipmentPrice], [EquipmentDescription], [StoreID], [EquipmentTypeID], [StatusID], [ProductImage]) VALUES (66, N'Garmin Approach S42 Golf GPS Watch', 299.9900, N'Simple, intuitive Golf GPS Watch designed to help golfers focus on the course
42,000 preloaded CourseView maps
Pairs with Garmin Golf™ app for analysis, tournaments and insights
Pairs with optional Approach® CT10 club tracking sensors (sold separately)
Up to 15 hours of battery life in GPS mode and 10 days in smartwatch mode
Lightweight and stylish smartwatch with 1.2” easy-to-read color touchscreen display
AutoShot round analyzer measure and auto-records detected shot distances
Green View feature offers manual pin positioning', 10, 4, 1, NULL)
GO
INSERT [dbo].[Equipment] ([EquipmentID], [EquipmentName], [EquipmentPrice], [EquipmentDescription], [StoreID], [EquipmentTypeID], [StatusID], [ProductImage]) VALUES (67, N'Pride PTS 3 1/4'''' White Golf Tees - 135 Pack', 14.9900, N'3 1/4"
135 Count', 1, 4, 1, NULL)
GO
INSERT [dbo].[Equipment] ([EquipmentID], [EquipmentName], [EquipmentPrice], [EquipmentDescription], [StoreID], [EquipmentTypeID], [StatusID], [ProductImage]) VALUES (68, N'Maxfli Assorted Rubber Range Golf Tees - 3 Pack', 6.9900, N'This 3 pack of tees includes a high tee that perfect for a driver, a mid-tee that is great for iron shots and traditional tee that is mounted in rubber for maximum versatility. Save time and money with these training aids so you can practice from home while shaving strokes off your score.', 4, 4, 2, NULL)
GO
INSERT [dbo].[Equipment] ([EquipmentID], [EquipmentName], [EquipmentPrice], [EquipmentDescription], [StoreID], [EquipmentTypeID], [StatusID], [ProductImage]) VALUES (69, N'Titleist Players Golf Towel', 25.0000, N'Tour-inspired design with woven ribbed pattern and red stripe accent
Constructed from maximum absorption terry material
Subtle woven label logo for sophisticated branding
Dimensions: 16”H x 32”W', 2, 4, 2, NULL)
GO
INSERT [dbo].[Equipment] ([EquipmentID], [EquipmentName], [EquipmentPrice], [EquipmentDescription], [StoreID], [EquipmentTypeID], [StatusID], [ProductImage]) VALUES (70, N'Nike Performance Golf Towel', 20.0000, N'Carabineer clasp provides quick and easy
Soft, moisture-absorbing fabric safely cleans clubs
Machine washable material for convenience
Size: 24" w x 16" h / 61 cm x 41 cm', 2, 4, 2, NULL)
GO
INSERT [dbo].[Equipment] ([EquipmentID], [EquipmentName], [EquipmentPrice], [EquipmentDescription], [StoreID], [EquipmentTypeID], [StatusID], [ProductImage]) VALUES (71, N'TaylorMade 15'''' Microfiber Cart Towel', 19.9900, N'Microfiber construction absorbs moisture
Waffle-weave pattern removes course debris
Nylon loop easily secures to bag
TaylorMade branding
15'''' x 24''''', 4, 4, 6, NULL)
GO
INSERT [dbo].[Equipment] ([EquipmentID], [EquipmentName], [EquipmentPrice], [EquipmentDescription], [StoreID], [EquipmentTypeID], [StatusID], [ProductImage]) VALUES (72, N'FootJoy WeatherSof Golf Glove - 2 Pack', 22.9900, N'Take performance and feel to new heights while wearing FootJoy WeatherSof Golf Gloves. Taction2® advanced performance leather pairs with premium Cabretta leather to increase feel, durability and flexibility in key stress areas. Breathable PowerNet™ mesh on the fingers and knuckles delivers cool comfort and flexibility. FiberSof™ microfiber along the fingers further elevates fit, grip security and range of motion through the swing.', 1, 4, 5, NULL)
GO
INSERT [dbo].[Equipment] ([EquipmentID], [EquipmentName], [EquipmentPrice], [EquipmentDescription], [StoreID], [EquipmentTypeID], [StatusID], [ProductImage]) VALUES (73, N'TaylorMade 2021 Tour Preferred Flex Golf Glove', 19.9900, N'AAA Cabretta Soft Tech™ Leather construction for incredible grip
4-way stretch nylon insert for fit and comfort
Strategically placed perforated leather for increased airflow
Contoured fit wrist band with moisture wicking', 4, 4, 5, NULL)
GO
INSERT [dbo].[Equipment] ([EquipmentID], [EquipmentName], [EquipmentPrice], [EquipmentDescription], [StoreID], [EquipmentTypeID], [StatusID], [ProductImage]) VALUES (74, N'PING Hat Clip & Ball Markers', 19.9900, N'There''s no need to jingle for a coin to mark your ball when you have the PING Hat Clip & Ball Markers. The small, low profile hat clip blends into the brim of your favorite hat for quick access on the green. A powerful magnet secures the ball marker to the hat so there''s no risk of it accidentally falling off. Each set includes a hat clip and two ball markers.', 10, 4, 1, NULL)
GO
INSERT [dbo].[Equipment] ([EquipmentID], [EquipmentName], [EquipmentPrice], [EquipmentDescription], [StoreID], [EquipmentTypeID], [StatusID], [ProductImage]) VALUES (77, N'USA Flag Crystal Ball Marker and Hat Clip Set', 19.9900, N'Women’s Crystal Hat Clip with magnet which is placed on bill of visor or cap with accompanying Crystal Ball Marker
Crystal Ball Marker adheres to Crystal Hat Clip for easy retrieval
Place your ball marker behind a golf ball during the process of marking your golf ball location on putting green
Includes 1 ball marker and 1 hat clip', 1, 4, 6, NULL)
GO
INSERT [dbo].[Equipment] ([EquipmentID], [EquipmentName], [EquipmentPrice], [EquipmentDescription], [StoreID], [EquipmentTypeID], [StatusID], [ProductImage]) VALUES (78, N'Callaway 4-in-1 Divot Repair Tool', 14.9900, N'Take proper care of your favorite course while getting some additional cleaning benefits with the Callaway® 4-in-1 Divot Repair Tool. This tool includes a magnetic ball marker, metal groove cleaner, and nylon bristle brush for general use on the course. The zinc alloy construction ensures that this tool will last for many rounds to come.', 10, 4, 4, NULL)
GO
INSERT [dbo].[Equipment] ([EquipmentID], [EquipmentName], [EquipmentPrice], [EquipmentDescription], [StoreID], [EquipmentTypeID], [StatusID], [ProductImage]) VALUES (79, N'YETI Tundra 45 Cooler', 325.0000, N'PermaFrost™ Insulation is pressure-injected commercial-grade polyurethane foam that delivers ultimate ice retention', 4, 4, 6, NULL)
GO
INSERT [dbo].[Equipment] ([EquipmentID], [EquipmentName], [EquipmentPrice], [EquipmentDescription], [StoreID], [EquipmentTypeID], [StatusID], [ProductImage]) VALUES (80, N'Titleist 2019 Perma Soft Golf Gloves', 21.9900, N'For superior grip and comfort every time you swing, sport the Titleist® 2019 Perma Soft Golf Gloves. Constructed with Cabretta leather, satin reinforcement, and CoolMax® Mesh, you’ll keep your cool and play with confidence whenever you swing.', 1, 4, 2, NULL)
GO
INSERT [dbo].[Equipment] ([EquipmentID], [EquipmentName], [EquipmentPrice], [EquipmentDescription], [StoreID], [EquipmentTypeID], [StatusID], [ProductImage]) VALUES (81, N'Nike Men''s 2021 Tour Classic IV Golf Glove ', 24.0000, N'mium leather for a soft feel and excellent fit, grip and durability
Stretch zones on back of hand and fingers for optimum range of motion
Perforations add breathability
Angled tab closure for an adjustable, comfortable fit
Palm Material: 100% Sheepskin leather
Back Material: 61% Goatskin leather, 32% Sheepskin leather, 7% Nylon
Other Material: 63% Goatskin leather, 22% PU leather, 15% Nylon', 2, 4, 2, NULL)
GO
INSERT [dbo].[Equipment] ([EquipmentID], [EquipmentName], [EquipmentPrice], [EquipmentDescription], [StoreID], [EquipmentTypeID], [StatusID], [ProductImage]) VALUES (82, N'PING 68" Tour Umbrella', 68.0000, N'Waterproof fabric
68” Double canopy allows airflow
PING Tour design accent
Simple-release deployment
Comfortable foam handle', 10, 4, 6, NULL)
GO
INSERT [dbo].[Equipment] ([EquipmentID], [EquipmentName], [EquipmentPrice], [EquipmentDescription], [StoreID], [EquipmentTypeID], [StatusID], [ProductImage]) VALUES (83, N'PING 62" Single Canopy Umbrella', 68.0000, N'Comfortable foam handle
Mr. PING tag design
Mr. PING badge design', 4, 4, 2, NULL)
GO
INSERT [dbo].[Equipment] ([EquipmentID], [EquipmentName], [EquipmentPrice], [EquipmentDescription], [StoreID], [EquipmentTypeID], [StatusID], [ProductImage]) VALUES (84, N'Nike Tiger Woods Limited Edition Irons ', 999.0000, NULL, 4, 1, 5, NULL)
GO
SET IDENTITY_INSERT [dbo].[Equipment] OFF
GO
SET IDENTITY_INSERT [dbo].[EquipmentStatus] ON 
GO
INSERT [dbo].[EquipmentStatus] ([StatusID], [StatusName]) VALUES (1, N'In-Stock')
GO
INSERT [dbo].[EquipmentStatus] ([StatusID], [StatusName]) VALUES (2, N'Out Of Stock')
GO
INSERT [dbo].[EquipmentStatus] ([StatusID], [StatusName]) VALUES (4, N'Back Ordered')
GO
INSERT [dbo].[EquipmentStatus] ([StatusID], [StatusName]) VALUES (5, N'Discontinued')
GO
INSERT [dbo].[EquipmentStatus] ([StatusID], [StatusName]) VALUES (6, N'On Order')
GO
SET IDENTITY_INSERT [dbo].[EquipmentStatus] OFF
GO
SET IDENTITY_INSERT [dbo].[EquipmentTypes] ON 
GO
INSERT [dbo].[EquipmentTypes] ([EquipmentTypeID], [TypeName]) VALUES (1, N'Golf Clubs')
GO
INSERT [dbo].[EquipmentTypes] ([EquipmentTypeID], [TypeName]) VALUES (2, N'Golf Apparel')
GO
INSERT [dbo].[EquipmentTypes] ([EquipmentTypeID], [TypeName]) VALUES (3, N'Golf Bags')
GO
INSERT [dbo].[EquipmentTypes] ([EquipmentTypeID], [TypeName]) VALUES (4, N'Accessories')
GO
INSERT [dbo].[EquipmentTypes] ([EquipmentTypeID], [TypeName]) VALUES (5, N'Golf balls')
GO
INSERT [dbo].[EquipmentTypes] ([EquipmentTypeID], [TypeName]) VALUES (6, N'Divot Tools')
GO
INSERT [dbo].[EquipmentTypes] ([EquipmentTypeID], [TypeName]) VALUES (8, N'Test')
GO
SET IDENTITY_INSERT [dbo].[EquipmentTypes] OFF
GO
SET IDENTITY_INSERT [dbo].[GolfStores] ON 
GO
INSERT [dbo].[GolfStores] ([StoreID], [StoreName], [PhoneNumber], [Region], [Country], [ZipCode], [State], [Address]) VALUES (1, N'EdwinWatts', N'913-111-2222', N'North America', N'US', N'66213     ', N'KS        ', N'1234 Albatross Rd')
GO
INSERT [dbo].[GolfStores] ([StoreID], [StoreName], [PhoneNumber], [Region], [Country], [ZipCode], [State], [Address]) VALUES (2, N'Dicks Sporting Goods', N'913-222-3333', N'Central America', N'US', N'66214     ', N'MO        ', N'5678 Eagle St')
GO
INSERT [dbo].[GolfStores] ([StoreID], [StoreName], [PhoneNumber], [Region], [Country], [ZipCode], [State], [Address]) VALUES (4, N'Clubhouse Golf', N'444-333-4444', N'England', N'UK', N'66215     ', N'CHESTER   ', N'9012 Birdie Ln')
GO
INSERT [dbo].[GolfStores] ([StoreID], [StoreName], [PhoneNumber], [Region], [Country], [ZipCode], [State], [Address]) VALUES (10, N'Golf Galaxy', N'913-444-5555', N'Central America', N'US', N'66216     ', N'TX        ', N'3456 Par Ave')
GO
SET IDENTITY_INSERT [dbo].[GolfStores] OFF
GO
ALTER TABLE [dbo].[Equipment]  WITH CHECK ADD  CONSTRAINT [FK_Equipment_EquipmentStatus] FOREIGN KEY([StatusID])
REFERENCES [dbo].[EquipmentStatus] ([StatusID])
GO
ALTER TABLE [dbo].[Equipment] CHECK CONSTRAINT [FK_Equipment_EquipmentStatus]
GO
ALTER TABLE [dbo].[Equipment]  WITH CHECK ADD  CONSTRAINT [FK_Equipment_EquipmentTypes] FOREIGN KEY([EquipmentTypeID])
REFERENCES [dbo].[EquipmentTypes] ([EquipmentTypeID])
GO
ALTER TABLE [dbo].[Equipment] CHECK CONSTRAINT [FK_Equipment_EquipmentTypes]
GO
ALTER TABLE [dbo].[Equipment]  WITH CHECK ADD  CONSTRAINT [FK_EquipmentStatuses_GolfStores] FOREIGN KEY([StoreID])
REFERENCES [dbo].[GolfStores] ([StoreID])
GO
ALTER TABLE [dbo].[Equipment] CHECK CONSTRAINT [FK_EquipmentStatuses_GolfStores]
GO
/****** Object:  StoredProcedure [dbo].[sprocFuzzySearch]    Script Date: 10/6/2022 3:37:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sprocFuzzySearch]
(
	@equipmentname VARCHAR(50)
	--@typename VARCHAR(50)
)
AS
BEGIN	
	SELECT DISTINCT
		e.EquipmentName AS [Equipment],
		et.TypeName AS [Equipment Category]
	FROM Equipment e
		INNER JOIN EquipmentTypes et
			ON e.EquipmentTypeID = et.EquipmentTypeID
WHERE e.EquipmentName LIKE '%' + @equipmentname + '%'
ORDER BY e.EquipmentName
END
GO
