CREATE SCHEMA auth;

CREATE SEQUENCE auth."AspNetRoleClaims_Id_seq"
    AS bigint
    INCREMENT 1
    START 1
    MINVALUE 1
    MAXVALUE 2147483647
    CACHE 1;

CREATE SEQUENCE auth."AspNetUserClaims_Id_seq"
    AS bigint
    INCREMENT 1
    START 1
    MINVALUE 1
    MAXVALUE 2147483647
    CACHE 1;

--
CREATE TABLE auth."AspNetRoles"
(
    "Id" text COLLATE pg_catalog."default" NOT NULL,
    "ConcurrencyStamp" text COLLATE pg_catalog."default",
    "Name" character varying(256) COLLATE pg_catalog."default",
    "NormalizedName" character varying(256) COLLATE pg_catalog."default",
    CONSTRAINT "PK_AspNetRoles" PRIMARY KEY ("Id")
);
 
CREATE UNIQUE INDEX "IX_AspNetRoles_NormalizedName"
    ON auth."AspNetRoles" ("NormalizedName");

--
CREATE TABLE auth."AspNetUsers"
(
    "Id" text COLLATE pg_catalog."default" NOT NULL,
    "AccessFailedCount" integer NOT NULL,
    "ConcurrencyStamp" text COLLATE pg_catalog."default",
    "Email" character varying(256) COLLATE pg_catalog."default",
    "EmailConfirmed" boolean NOT NULL,
    "LockoutEnabled" boolean NOT NULL,
    "LockoutEnd" timestamp with time zone,
    "NormalizedEmail" character varying(256) COLLATE pg_catalog."default",
    "NormalizedUserName" character varying(256) COLLATE pg_catalog."default",
    "PasswordHash" text COLLATE pg_catalog."default",
    "PhoneNumber" text COLLATE pg_catalog."default",
    "PhoneNumberConfirmed" boolean NOT NULL,
    "SecurityStamp" text COLLATE pg_catalog."default",
    "TwoFactorEnabled" boolean NOT NULL,
    "UserName" character varying(256) COLLATE pg_catalog."default",
    CONSTRAINT "PK_AspNetUsers" PRIMARY KEY ("Id")
);

CREATE INDEX "EmailIndex"
    ON auth."AspNetUsers" ("NormalizedEmail");

CREATE UNIQUE INDEX "UserNameIndex"
    ON auth."AspNetUsers" ("NormalizedUserName");


CREATE TABLE auth."AspNetRoleClaims"
(
    "Id" bigint NOT NULL DEFAULT nextval('auth."AspNetRoleClaims_Id_seq"'::regclass),
    "ClaimType" text COLLATE pg_catalog."default",
    "ClaimValue" text COLLATE pg_catalog."default",
    "RoleId" text COLLATE pg_catalog."default" NOT NULL,
    CONSTRAINT "PK_AspNetRoleClaims" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_AspNetRoleClaims_AspNetRoles_RoleId" FOREIGN KEY ("RoleId")
        REFERENCES auth."AspNetRoles" ("Id") MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE CASCADE
);

CREATE INDEX "IX_AspNetRoleClaims_RoleId"
    ON auth."AspNetRoleClaims" ("RoleId");
  

--
-- Table: auth."AspNetUserLogins"

-- DROP TABLE auth."AspNetUserLogins";

CREATE TABLE auth."AspNetUserLogins"
(
    "LoginProvider" text COLLATE pg_catalog."default" NOT NULL,
    "ProviderKey" text COLLATE pg_catalog."default" NOT NULL,
    "ProviderDisplayName" text COLLATE pg_catalog."default",
    "UserId" text COLLATE pg_catalog."default" NOT NULL,
    CONSTRAINT "PK_AspNetUserLogins" PRIMARY KEY ("LoginProvider", "ProviderKey"),
    CONSTRAINT "FK_AspNetUserLogins_AspNetUsers_UserId" FOREIGN KEY ("UserId")
        REFERENCES auth."AspNetUsers" ("Id") MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE CASCADE
);

CREATE INDEX "IX_AspNetUserLogins_UserId"
    ON auth."AspNetUserLogins" ("UserId");


CREATE TABLE auth."AspNetUserRoles"
(
    "UserId" text COLLATE pg_catalog."default" NOT NULL,
    "RoleId" text COLLATE pg_catalog."default" NOT NULL,
    CONSTRAINT "PK_AspNetUserRoles" PRIMARY KEY ("UserId", "RoleId"),
    CONSTRAINT "FK_AspNetUserRoles_AspNetRoles_RoleId" FOREIGN KEY ("RoleId")
        REFERENCES auth."AspNetRoles" ("Id") MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE CASCADE,
    CONSTRAINT "FK_AspNetUserRoles_AspNetUsers_UserId" FOREIGN KEY ("UserId")
        REFERENCES auth."AspNetUsers" ("Id") MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE CASCADE
);

CREATE INDEX "IX_AspNetUserRoles_RoleId"
    ON auth."AspNetUserRoles" ("RoleId");

--
CREATE TABLE auth."AspNetUserTokens"
(
    "UserId" text COLLATE pg_catalog."default" NOT NULL,
    "LoginProvider" text COLLATE pg_catalog."default" NOT NULL,
    "Name" text COLLATE pg_catalog."default" NOT NULL,
    "Value" text COLLATE pg_catalog."default",
    CONSTRAINT "PK_AspNetUserTokens" PRIMARY KEY ("UserId", "LoginProvider", "Name"),
    CONSTRAINT "FK_AspNetUserTokens_AspNetUsers_UserId" FOREIGN KEY ("UserId")
        REFERENCES auth."AspNetUsers" ("Id") MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE CASCADE
);


