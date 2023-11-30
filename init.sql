--
-- PostgreSQL database dump
--

-- Dumped from database version 16.1 (Debian 16.1-1.pgdg120+1)
-- Dumped by pg_dump version 16.0

-- Started on 2023-11-30 20:06:03

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

--
-- TOC entry 3548 (class 1262 OID 16388)
-- Name: labworks; Type: DATABASE; Schema: -; Owner: postgres
--

CREATE DATABASE labworks WITH TEMPLATE = template0 ENCODING = 'UTF8' LOCALE_PROVIDER = libc LOCALE = 'en_US.utf8';


ALTER DATABASE labworks OWNER TO postgres;

\connect labworks

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- TOC entry 217 (class 1259 OID 16397)
-- Name: course; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.course (
    id integer NOT NULL
);


ALTER TABLE public.course OWNER TO postgres;

--
-- TOC entry 216 (class 1259 OID 16396)
-- Name: Courses_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."Courses_id_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public."Courses_id_seq" OWNER TO postgres;

--
-- TOC entry 3549 (class 0 OID 0)
-- Dependencies: 216
-- Name: Courses_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."Courses_id_seq" OWNED BY public.course.id;


--
-- TOC entry 222 (class 1259 OID 16419)
-- Name: discipline; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.discipline (
    id integer NOT NULL,
    name character varying(100) NOT NULL
);


ALTER TABLE public.discipline OWNER TO postgres;

--
-- TOC entry 221 (class 1259 OID 16418)
-- Name: Disciplines_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."Disciplines_id_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public."Disciplines_id_seq" OWNER TO postgres;

--
-- TOC entry 3550 (class 0 OID 0)
-- Dependencies: 221
-- Name: Disciplines_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."Disciplines_id_seq" OWNED BY public.discipline.id;


--
-- TOC entry 228 (class 1259 OID 16448)
-- Name: group; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."group" (
    id integer NOT NULL,
    name character varying(40) NOT NULL,
    year integer NOT NULL,
    course_id integer NOT NULL,
    semester_id integer NOT NULL
);


ALTER TABLE public."group" OWNER TO postgres;

--
-- TOC entry 227 (class 1259 OID 16447)
-- Name: Groups_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."Groups_id_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public."Groups_id_seq" OWNER TO postgres;

--
-- TOC entry 3551 (class 0 OID 0)
-- Dependencies: 227
-- Name: Groups_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."Groups_id_seq" OWNED BY public."group".id;


--
-- TOC entry 232 (class 1259 OID 16532)
-- Name: mark; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.mark (
    id integer NOT NULL,
    value integer NOT NULL
);


ALTER TABLE public.mark OWNER TO postgres;

--
-- TOC entry 231 (class 1259 OID 16531)
-- Name: Mark_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."Mark_id_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public."Mark_id_seq" OWNER TO postgres;

--
-- TOC entry 3552 (class 0 OID 0)
-- Dependencies: 231
-- Name: Mark_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."Mark_id_seq" OWNED BY public.mark.id;


--
-- TOC entry 220 (class 1259 OID 16412)
-- Name: semester; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.semester (
    id integer NOT NULL
);


ALTER TABLE public.semester OWNER TO postgres;

--
-- TOC entry 219 (class 1259 OID 16411)
-- Name: Semesters_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."Semesters_id_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public."Semesters_id_seq" OWNER TO postgres;

--
-- TOC entry 3553 (class 0 OID 0)
-- Dependencies: 219
-- Name: Semesters_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."Semesters_id_seq" OWNED BY public.semester.id;


--
-- TOC entry 226 (class 1259 OID 16440)
-- Name: student; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.student (
    id integer NOT NULL,
    is_retired boolean DEFAULT false NOT NULL,
    user_id integer NOT NULL,
    group_id integer NOT NULL
);


ALTER TABLE public.student OWNER TO postgres;

--
-- TOC entry 225 (class 1259 OID 16439)
-- Name: Students_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."Students_id_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public."Students_id_seq" OWNER TO postgres;

--
-- TOC entry 3554 (class 0 OID 0)
-- Dependencies: 225
-- Name: Students_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."Students_id_seq" OWNED BY public.student.id;


--
-- TOC entry 224 (class 1259 OID 16428)
-- Name: teacher; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.teacher (
    id integer NOT NULL,
    user_id integer NOT NULL
);


ALTER TABLE public.teacher OWNER TO postgres;

--
-- TOC entry 223 (class 1259 OID 16427)
-- Name: Teachers_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."Teachers_id_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public."Teachers_id_seq" OWNER TO postgres;

--
-- TOC entry 3555 (class 0 OID 0)
-- Dependencies: 223
-- Name: Teachers_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."Teachers_id_seq" OWNED BY public.teacher.id;


--
-- TOC entry 215 (class 1259 OID 16389)
-- Name: user; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."user" (
    login character varying(50) NOT NULL,
    password character varying(100) NOT NULL,
    name character varying(100) NOT NULL,
    surname character varying(100) NOT NULL,
    patronymic character varying(100) NOT NULL,
    id integer NOT NULL
);


ALTER TABLE public."user" OWNER TO postgres;

--
-- TOC entry 218 (class 1259 OID 16403)
-- Name: Users_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."Users_id_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public."Users_id_seq" OWNER TO postgres;

--
-- TOC entry 3556 (class 0 OID 0)
-- Dependencies: 218
-- Name: Users_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."Users_id_seq" OWNED BY public."user".id;


--
-- TOC entry 234 (class 1259 OID 16548)
-- Name: work_type; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.work_type (
    id integer NOT NULL,
    name character varying(30) NOT NULL
);


ALTER TABLE public.work_type OWNER TO postgres;

--
-- TOC entry 233 (class 1259 OID 16547)
-- Name: WorkType_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."WorkType_id_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public."WorkType_id_seq" OWNER TO postgres;

--
-- TOC entry 3557 (class 0 OID 0)
-- Dependencies: 233
-- Name: WorkType_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."WorkType_id_seq" OWNED BY public.work_type.id;


--
-- TOC entry 243 (class 1259 OID 16632)
-- Name: completed_work; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.completed_work (
    id integer NOT NULL,
    percentage integer NOT NULL,
    mark_id integer NOT NULL,
    work_id integer NOT NULL,
    student_id integer NOT NULL
);


ALTER TABLE public.completed_work OWNER TO postgres;

--
-- TOC entry 242 (class 1259 OID 16631)
-- Name: completed_work_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.completed_work_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.completed_work_id_seq OWNER TO postgres;

--
-- TOC entry 3558 (class 0 OID 0)
-- Dependencies: 242
-- Name: completed_work_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.completed_work_id_seq OWNED BY public.completed_work.id;


--
-- TOC entry 244 (class 1259 OID 16653)
-- Name: completed_work_task; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.completed_work_task (
    completed_work_id integer NOT NULL,
    task_id integer NOT NULL
);


ALTER TABLE public.completed_work_task OWNER TO postgres;

--
-- TOC entry 230 (class 1259 OID 16516)
-- Name: group_discipline; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.group_discipline (
    group_id integer NOT NULL,
    discipline_id integer NOT NULL
);


ALTER TABLE public.group_discipline OWNER TO postgres;

--
-- TOC entry 241 (class 1259 OID 16600)
-- Name: group_work; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.group_work (
    group_id integer NOT NULL,
    work_id integer NOT NULL,
    discipline_id integer NOT NULL,
    course_id integer NOT NULL,
    semester_id integer NOT NULL,
    id integer NOT NULL
);


ALTER TABLE public.group_work OWNER TO postgres;

--
-- TOC entry 240 (class 1259 OID 16599)
-- Name: group_work_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.group_work_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.group_work_id_seq OWNER TO postgres;

--
-- TOC entry 3559 (class 0 OID 0)
-- Dependencies: 240
-- Name: group_work_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.group_work_id_seq OWNED BY public.group_work.id;


--
-- TOC entry 245 (class 1259 OID 24577)
-- Name: session; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.session (
    user_id integer NOT NULL,
    id uuid NOT NULL,
    refresh_token character varying(4096) NOT NULL
);


ALTER TABLE public.session OWNER TO postgres;

--
-- TOC entry 238 (class 1259 OID 16569)
-- Name: task; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.task (
    id integer NOT NULL,
    title character varying(300) NOT NULL,
    description character varying(5000) NOT NULL,
    work_id integer NOT NULL
);


ALTER TABLE public.task OWNER TO postgres;

--
-- TOC entry 237 (class 1259 OID 16568)
-- Name: task_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.task_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.task_id_seq OWNER TO postgres;

--
-- TOC entry 3560 (class 0 OID 0)
-- Dependencies: 237
-- Name: task_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.task_id_seq OWNED BY public.task.id;


--
-- TOC entry 229 (class 1259 OID 16476)
-- Name: teacher_group; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.teacher_group (
    teacher_id integer NOT NULL,
    group_id integer NOT NULL
);


ALTER TABLE public.teacher_group OWNER TO postgres;

--
-- TOC entry 236 (class 1259 OID 16557)
-- Name: work; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.work (
    id integer NOT NULL,
    name character varying(300) NOT NULL,
    work_type_id integer NOT NULL
);


ALTER TABLE public.work OWNER TO postgres;

--
-- TOC entry 235 (class 1259 OID 16556)
-- Name: work_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.work_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.work_id_seq OWNER TO postgres;

--
-- TOC entry 3561 (class 0 OID 0)
-- Dependencies: 235
-- Name: work_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.work_id_seq OWNED BY public.work.id;


--
-- TOC entry 239 (class 1259 OID 16582)
-- Name: work_mark; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.work_mark (
    work_id integer NOT NULL,
    mark_id integer NOT NULL,
    task_count integer NOT NULL
);


ALTER TABLE public.work_mark OWNER TO postgres;

--
-- TOC entry 3296 (class 2604 OID 16635)
-- Name: completed_work id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.completed_work ALTER COLUMN id SET DEFAULT nextval('public.completed_work_id_seq'::regclass);


--
-- TOC entry 3284 (class 2604 OID 16400)
-- Name: course id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.course ALTER COLUMN id SET DEFAULT nextval('public."Courses_id_seq"'::regclass);


--
-- TOC entry 3286 (class 2604 OID 16422)
-- Name: discipline id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.discipline ALTER COLUMN id SET DEFAULT nextval('public."Disciplines_id_seq"'::regclass);


--
-- TOC entry 3290 (class 2604 OID 16451)
-- Name: group id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."group" ALTER COLUMN id SET DEFAULT nextval('public."Groups_id_seq"'::regclass);


--
-- TOC entry 3295 (class 2604 OID 16603)
-- Name: group_work id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.group_work ALTER COLUMN id SET DEFAULT nextval('public.group_work_id_seq'::regclass);


--
-- TOC entry 3291 (class 2604 OID 16535)
-- Name: mark id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.mark ALTER COLUMN id SET DEFAULT nextval('public."Mark_id_seq"'::regclass);


--
-- TOC entry 3285 (class 2604 OID 16415)
-- Name: semester id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.semester ALTER COLUMN id SET DEFAULT nextval('public."Semesters_id_seq"'::regclass);


--
-- TOC entry 3288 (class 2604 OID 16443)
-- Name: student id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.student ALTER COLUMN id SET DEFAULT nextval('public."Students_id_seq"'::regclass);


--
-- TOC entry 3294 (class 2604 OID 16572)
-- Name: task id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.task ALTER COLUMN id SET DEFAULT nextval('public.task_id_seq'::regclass);


--
-- TOC entry 3287 (class 2604 OID 16431)
-- Name: teacher id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.teacher ALTER COLUMN id SET DEFAULT nextval('public."Teachers_id_seq"'::regclass);


--
-- TOC entry 3283 (class 2604 OID 16404)
-- Name: user id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."user" ALTER COLUMN id SET DEFAULT nextval('public."Users_id_seq"'::regclass);


--
-- TOC entry 3293 (class 2604 OID 16560)
-- Name: work id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.work ALTER COLUMN id SET DEFAULT nextval('public.work_id_seq'::regclass);


--
-- TOC entry 3292 (class 2604 OID 16551)
-- Name: work_type id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.work_type ALTER COLUMN id SET DEFAULT nextval('public."WorkType_id_seq"'::regclass);


--
-- TOC entry 3540 (class 0 OID 16632)
-- Dependencies: 243
-- Data for Name: completed_work; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.completed_work (id, percentage, mark_id, work_id, student_id) FROM stdin;
\.


--
-- TOC entry 3541 (class 0 OID 16653)
-- Dependencies: 244
-- Data for Name: completed_work_task; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.completed_work_task (completed_work_id, task_id) FROM stdin;
\.


--
-- TOC entry 3514 (class 0 OID 16397)
-- Dependencies: 217
-- Data for Name: course; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.course (id) FROM stdin;
4
3
2
1
5
\.


--
-- TOC entry 3519 (class 0 OID 16419)
-- Dependencies: 222
-- Data for Name: discipline; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.discipline (id, name) FROM stdin;
2	МДК какое то
\.


--
-- TOC entry 3525 (class 0 OID 16448)
-- Dependencies: 228
-- Data for Name: group; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."group" (id, name, year, course_id, semester_id) FROM stdin;
2	ИСПП-01	2020	4	1
\.


--
-- TOC entry 3527 (class 0 OID 16516)
-- Dependencies: 230
-- Data for Name: group_discipline; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.group_discipline (group_id, discipline_id) FROM stdin;
2	2
\.


--
-- TOC entry 3538 (class 0 OID 16600)
-- Dependencies: 241
-- Data for Name: group_work; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.group_work (group_id, work_id, discipline_id, course_id, semester_id, id) FROM stdin;
\.


--
-- TOC entry 3529 (class 0 OID 16532)
-- Dependencies: 232
-- Data for Name: mark; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.mark (id, value) FROM stdin;
1	5
2	4
3	3
4	2
\.


--
-- TOC entry 3517 (class 0 OID 16412)
-- Dependencies: 220
-- Data for Name: semester; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.semester (id) FROM stdin;
2
1
\.


--
-- TOC entry 3542 (class 0 OID 24577)
-- Dependencies: 245
-- Data for Name: session; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.session (user_id, id, refresh_token) FROM stdin;
\.


--
-- TOC entry 3523 (class 0 OID 16440)
-- Dependencies: 226
-- Data for Name: student; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.student (id, is_retired, user_id, group_id) FROM stdin;
\.


--
-- TOC entry 3535 (class 0 OID 16569)
-- Dependencies: 238
-- Data for Name: task; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.task (id, title, description, work_id) FROM stdin;
\.


--
-- TOC entry 3521 (class 0 OID 16428)
-- Dependencies: 224
-- Data for Name: teacher; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.teacher (id, user_id) FROM stdin;
\.


--
-- TOC entry 3526 (class 0 OID 16476)
-- Dependencies: 229
-- Data for Name: teacher_group; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.teacher_group (teacher_id, group_id) FROM stdin;
\.


--
-- TOC entry 3512 (class 0 OID 16389)
-- Dependencies: 215
-- Data for Name: user; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."user" (login, password, name, surname, patronymic, id) FROM stdin;
string	string	string	string	string	1
string2	string	string	string	string	3
teac2	string	string	string2	string	4
\.


--
-- TOC entry 3533 (class 0 OID 16557)
-- Dependencies: 236
-- Data for Name: work; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.work (id, name, work_type_id) FROM stdin;
\.


--
-- TOC entry 3536 (class 0 OID 16582)
-- Dependencies: 239
-- Data for Name: work_mark; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.work_mark (work_id, mark_id, task_count) FROM stdin;
\.


--
-- TOC entry 3531 (class 0 OID 16548)
-- Dependencies: 234
-- Data for Name: work_type; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.work_type (id, name) FROM stdin;
\.


--
-- TOC entry 3562 (class 0 OID 0)
-- Dependencies: 216
-- Name: Courses_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."Courses_id_seq"', 1, false);


--
-- TOC entry 3563 (class 0 OID 0)
-- Dependencies: 221
-- Name: Disciplines_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."Disciplines_id_seq"', 2, true);


--
-- TOC entry 3564 (class 0 OID 0)
-- Dependencies: 227
-- Name: Groups_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."Groups_id_seq"', 2, true);


--
-- TOC entry 3565 (class 0 OID 0)
-- Dependencies: 231
-- Name: Mark_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."Mark_id_seq"', 4, true);


--
-- TOC entry 3566 (class 0 OID 0)
-- Dependencies: 219
-- Name: Semesters_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."Semesters_id_seq"', 1, false);


--
-- TOC entry 3567 (class 0 OID 0)
-- Dependencies: 225
-- Name: Students_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."Students_id_seq"', 2, true);


--
-- TOC entry 3568 (class 0 OID 0)
-- Dependencies: 223
-- Name: Teachers_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."Teachers_id_seq"', 1, true);


--
-- TOC entry 3569 (class 0 OID 0)
-- Dependencies: 218
-- Name: Users_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."Users_id_seq"', 4, true);


--
-- TOC entry 3570 (class 0 OID 0)
-- Dependencies: 233
-- Name: WorkType_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."WorkType_id_seq"', 1, true);


--
-- TOC entry 3571 (class 0 OID 0)
-- Dependencies: 242
-- Name: completed_work_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.completed_work_id_seq', 1, false);


--
-- TOC entry 3572 (class 0 OID 0)
-- Dependencies: 240
-- Name: group_work_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.group_work_id_seq', 1, false);


--
-- TOC entry 3573 (class 0 OID 0)
-- Dependencies: 237
-- Name: task_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.task_id_seq', 1, false);


--
-- TOC entry 3574 (class 0 OID 0)
-- Dependencies: 235
-- Name: work_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.work_id_seq', 1, false);


--
-- TOC entry 3340 (class 2606 OID 16637)
-- Name: completed_work completed_work_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.completed_work
    ADD CONSTRAINT completed_work_pkey PRIMARY KEY (id);


--
-- TOC entry 3342 (class 2606 OID 16657)
-- Name: completed_work_task completed_work_task_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.completed_work_task
    ADD CONSTRAINT completed_work_task_pkey PRIMARY KEY (task_id, completed_work_id);


--
-- TOC entry 3302 (class 2606 OID 16402)
-- Name: course course_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.course
    ADD CONSTRAINT course_pkey PRIMARY KEY (id);


--
-- TOC entry 3306 (class 2606 OID 16424)
-- Name: discipline discipline_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.discipline
    ADD CONSTRAINT discipline_pkey PRIMARY KEY (id);


--
-- TOC entry 3308 (class 2606 OID 16426)
-- Name: discipline discipline_unique_name; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.discipline
    ADD CONSTRAINT discipline_unique_name UNIQUE (name);


--
-- TOC entry 3320 (class 2606 OID 16520)
-- Name: group_discipline group_discipline_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.group_discipline
    ADD CONSTRAINT group_discipline_pkey PRIMARY KEY (group_id, discipline_id);


--
-- TOC entry 3314 (class 2606 OID 16453)
-- Name: group group_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."group"
    ADD CONSTRAINT group_pkey PRIMARY KEY (id);


--
-- TOC entry 3316 (class 2606 OID 16455)
-- Name: group group_unique_name_year; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."group"
    ADD CONSTRAINT group_unique_name_year UNIQUE (name, year);


--
-- TOC entry 3338 (class 2606 OID 16605)
-- Name: group_work group_work_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.group_work
    ADD CONSTRAINT group_work_pkey PRIMARY KEY (id);


--
-- TOC entry 3322 (class 2606 OID 16537)
-- Name: mark mark_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.mark
    ADD CONSTRAINT mark_pkey PRIMARY KEY (id);


--
-- TOC entry 3324 (class 2606 OID 16539)
-- Name: mark mark_unique_value; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.mark
    ADD CONSTRAINT mark_unique_value UNIQUE (value);


--
-- TOC entry 3304 (class 2606 OID 16417)
-- Name: semester semester_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.semester
    ADD CONSTRAINT semester_pkey PRIMARY KEY (id);


--
-- TOC entry 3344 (class 2606 OID 24591)
-- Name: session session_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.session
    ADD CONSTRAINT session_pkey PRIMARY KEY (id);


--
-- TOC entry 3312 (class 2606 OID 16446)
-- Name: student student_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.student
    ADD CONSTRAINT student_pkey PRIMARY KEY (id);


--
-- TOC entry 3332 (class 2606 OID 16576)
-- Name: task task_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.task
    ADD CONSTRAINT task_pkey PRIMARY KEY (id);


--
-- TOC entry 3318 (class 2606 OID 16480)
-- Name: teacher_group teacher_group_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.teacher_group
    ADD CONSTRAINT teacher_group_pkey PRIMARY KEY (teacher_id, group_id);


--
-- TOC entry 3310 (class 2606 OID 16433)
-- Name: teacher teacher_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.teacher
    ADD CONSTRAINT teacher_pkey PRIMARY KEY (id);


--
-- TOC entry 3298 (class 2606 OID 16410)
-- Name: user user_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."user"
    ADD CONSTRAINT user_pkey PRIMARY KEY (id);


--
-- TOC entry 3300 (class 2606 OID 16395)
-- Name: user user_unique_login; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."user"
    ADD CONSTRAINT user_unique_login UNIQUE (login);


--
-- TOC entry 3334 (class 2606 OID 16586)
-- Name: work_mark work_mark_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.work_mark
    ADD CONSTRAINT work_mark_pkey PRIMARY KEY (work_id);


--
-- TOC entry 3336 (class 2606 OID 16598)
-- Name: work_mark work_mark_unique_work_id_task_count; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.work_mark
    ADD CONSTRAINT work_mark_unique_work_id_task_count UNIQUE (work_id, task_count);


--
-- TOC entry 3330 (class 2606 OID 16562)
-- Name: work work_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.work
    ADD CONSTRAINT work_pkey PRIMARY KEY (id);


--
-- TOC entry 3326 (class 2606 OID 16553)
-- Name: work_type work_type_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.work_type
    ADD CONSTRAINT work_type_pkey PRIMARY KEY (id);


--
-- TOC entry 3328 (class 2606 OID 16555)
-- Name: work_type work_type_unique_name; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.work_type
    ADD CONSTRAINT work_type_unique_name UNIQUE (name);


--
-- TOC entry 3363 (class 2606 OID 16638)
-- Name: completed_work completed_work_fk_mark; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.completed_work
    ADD CONSTRAINT completed_work_fk_mark FOREIGN KEY (mark_id) REFERENCES public.mark(id) ON UPDATE CASCADE ON DELETE CASCADE;


--
-- TOC entry 3364 (class 2606 OID 16648)
-- Name: completed_work completed_work_fk_student; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.completed_work
    ADD CONSTRAINT completed_work_fk_student FOREIGN KEY (student_id) REFERENCES public.student(id) ON UPDATE CASCADE ON DELETE CASCADE;


--
-- TOC entry 3365 (class 2606 OID 16643)
-- Name: completed_work completed_work_fk_work; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.completed_work
    ADD CONSTRAINT completed_work_fk_work FOREIGN KEY (work_id) REFERENCES public.work(id) ON UPDATE CASCADE ON DELETE CASCADE;


--
-- TOC entry 3366 (class 2606 OID 16658)
-- Name: completed_work_task completed_work_task_fk_completed_work; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.completed_work_task
    ADD CONSTRAINT completed_work_task_fk_completed_work FOREIGN KEY (completed_work_id) REFERENCES public.completed_work(id) ON UPDATE CASCADE ON DELETE CASCADE;


--
-- TOC entry 3367 (class 2606 OID 16663)
-- Name: completed_work_task completed_work_task_fk_task; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.completed_work_task
    ADD CONSTRAINT completed_work_task_fk_task FOREIGN KEY (task_id) REFERENCES public.task(id) ON UPDATE CASCADE ON DELETE CASCADE;


--
-- TOC entry 3352 (class 2606 OID 16526)
-- Name: group_discipline group_discipline_fk_discipline; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.group_discipline
    ADD CONSTRAINT group_discipline_fk_discipline FOREIGN KEY (discipline_id) REFERENCES public.discipline(id) ON UPDATE CASCADE ON DELETE CASCADE;


--
-- TOC entry 3353 (class 2606 OID 16521)
-- Name: group_discipline group_discipline_fk_group; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.group_discipline
    ADD CONSTRAINT group_discipline_fk_group FOREIGN KEY (group_id) REFERENCES public."group"(id) ON UPDATE CASCADE ON DELETE CASCADE;


--
-- TOC entry 3348 (class 2606 OID 16491)
-- Name: group group_fk_course; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."group"
    ADD CONSTRAINT group_fk_course FOREIGN KEY (course_id) REFERENCES public.course(id) ON UPDATE CASCADE ON DELETE CASCADE NOT VALID;


--
-- TOC entry 3349 (class 2606 OID 16496)
-- Name: group group_fk_semester; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."group"
    ADD CONSTRAINT group_fk_semester FOREIGN KEY (semester_id) REFERENCES public.semester(id) ON UPDATE CASCADE ON DELETE CASCADE NOT VALID;


--
-- TOC entry 3358 (class 2606 OID 16621)
-- Name: group_work group_work_fk_course; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.group_work
    ADD CONSTRAINT group_work_fk_course FOREIGN KEY (course_id) REFERENCES public.course(id) ON UPDATE CASCADE ON DELETE CASCADE;


--
-- TOC entry 3359 (class 2606 OID 16616)
-- Name: group_work group_work_fk_discipline; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.group_work
    ADD CONSTRAINT group_work_fk_discipline FOREIGN KEY (discipline_id) REFERENCES public.discipline(id) ON UPDATE CASCADE ON DELETE CASCADE;


--
-- TOC entry 3360 (class 2606 OID 16606)
-- Name: group_work group_work_fk_group; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.group_work
    ADD CONSTRAINT group_work_fk_group FOREIGN KEY (group_id) REFERENCES public."group"(id) ON UPDATE CASCADE ON DELETE CASCADE;


--
-- TOC entry 3361 (class 2606 OID 16626)
-- Name: group_work group_work_fk_semester; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.group_work
    ADD CONSTRAINT group_work_fk_semester FOREIGN KEY (semester_id) REFERENCES public.semester(id) ON UPDATE CASCADE ON DELETE CASCADE;


--
-- TOC entry 3362 (class 2606 OID 16611)
-- Name: group_work group_work_fk_work; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.group_work
    ADD CONSTRAINT group_work_fk_work FOREIGN KEY (work_id) REFERENCES public.work(id) ON UPDATE CASCADE ON DELETE CASCADE;


--
-- TOC entry 3368 (class 2606 OID 24583)
-- Name: session session_fk_user; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.session
    ADD CONSTRAINT session_fk_user FOREIGN KEY (user_id) REFERENCES public."user"(id);


--
-- TOC entry 3346 (class 2606 OID 16506)
-- Name: student student_fk_group; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.student
    ADD CONSTRAINT student_fk_group FOREIGN KEY (group_id) REFERENCES public."group"(id) ON UPDATE CASCADE ON DELETE CASCADE NOT VALID;


--
-- TOC entry 3347 (class 2606 OID 16501)
-- Name: student student_fk_user; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.student
    ADD CONSTRAINT student_fk_user FOREIGN KEY (user_id) REFERENCES public."user"(id) ON UPDATE CASCADE ON DELETE CASCADE NOT VALID;


--
-- TOC entry 3355 (class 2606 OID 16577)
-- Name: task task_fk_work; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.task
    ADD CONSTRAINT task_fk_work FOREIGN KEY (work_id) REFERENCES public.work(id) ON UPDATE CASCADE ON DELETE CASCADE;


--
-- TOC entry 3345 (class 2606 OID 16511)
-- Name: teacher teacher_fk_user; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.teacher
    ADD CONSTRAINT teacher_fk_user FOREIGN KEY (user_id) REFERENCES public."user"(id) ON UPDATE CASCADE ON DELETE CASCADE NOT VALID;


--
-- TOC entry 3350 (class 2606 OID 16486)
-- Name: teacher_group teacher_group_fk_group; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.teacher_group
    ADD CONSTRAINT teacher_group_fk_group FOREIGN KEY (group_id) REFERENCES public."group"(id) ON UPDATE CASCADE ON DELETE CASCADE;


--
-- TOC entry 3351 (class 2606 OID 16481)
-- Name: teacher_group teacher_group_fk_teacher; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.teacher_group
    ADD CONSTRAINT teacher_group_fk_teacher FOREIGN KEY (teacher_id) REFERENCES public.teacher(id) ON UPDATE CASCADE ON DELETE CASCADE;


--
-- TOC entry 3354 (class 2606 OID 16563)
-- Name: work work_fk_work_type; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.work
    ADD CONSTRAINT work_fk_work_type FOREIGN KEY (work_type_id) REFERENCES public.work_type(id) ON UPDATE CASCADE ON DELETE CASCADE;


--
-- TOC entry 3356 (class 2606 OID 16592)
-- Name: work_mark work_mark_fk_mark; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.work_mark
    ADD CONSTRAINT work_mark_fk_mark FOREIGN KEY (mark_id) REFERENCES public.mark(id) ON UPDATE CASCADE ON DELETE CASCADE;


--
-- TOC entry 3357 (class 2606 OID 16587)
-- Name: work_mark work_mark_fk_work; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.work_mark
    ADD CONSTRAINT work_mark_fk_work FOREIGN KEY (work_id) REFERENCES public.work(id) ON UPDATE CASCADE ON DELETE CASCADE;


-- Completed on 2023-11-30 20:06:03

--
-- PostgreSQL database dump complete
--

